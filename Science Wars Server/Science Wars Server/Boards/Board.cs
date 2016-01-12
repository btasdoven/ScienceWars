using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Paths;
using Science_Wars_Server.Towers;
using Science_Wars_Server.ResourceManager;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Boards
{
    public abstract class Board : IRequiresResource
    {
        private static int idGenerator = 0;
        public int instanceId;

        protected Board()
        {
            instanceId = idGenerator++;
        }

        public Vector3 position;
        public Vector3 rotation;

        public Player player;        
        public Dictionary<int, Minion> minions = new Dictionary<int, Minion>();
        public Tower[] towers;                         // constructor da "new Tower[ towerSlots.Length ]" kullanarak initialize etmeyi unutmayin.

        public Board nextBoard;            //Like a linked list
        public Board prevBoard;

        #region MinionList Modifiers

        List<Minion> toBeRemovedMinions = new List<Minion>();
        List<Minion> toBeAddedMinions = new List<Minion>();

        #endregion


        #region Destruction Animation
        public enum BoardState {NORMAL, MOVING, COLLAPSING, COLLAPSED}
        public BoardState boardState = BoardState.NORMAL;
        public Vector3 startPosition;
        public Vector3 startRotation;
        public Vector3 targetPosition;
        public Vector3 targetRotation;
        private float totalAnimationTime = 5f;  // animasyonun 5 saniyede tamamlanmasini istiyoruz.
        #endregion

        public void step()
        {
            if (player.game.gameState == Game.GameState.PLAYTIME)
            {
                stepMinions();
                stepTowers();
            }

            stepMovement();
        }

        private void stepTowers()
        {
            for (int i = 0; i < towers.Length; i++)
            {
                if (towers[i] != null)
                {
                    if (towers[i].destroyable)
                        towers[i] = null;
                    else
                        towers[i].step();
                }
            }
        }
        private void stepMinions()
        {
            
            foreach (var minion in minions)
            {
                if (minion.Value != null)
                {
                    if (minion.Value.destroyable || minion.Value.position.board != this)
                    {
                        toBeRemovedMinions.Add(minion.Value);
                    }
                    else
                        minion.Value.step();
                }
            }

            foreach (var minion in toBeRemovedMinions)
                if(minions.ContainsKey(minion.instanceId))
                    minions.Remove(minion.instanceId);

            foreach (var minion in toBeAddedMinions)
                if(minions.ContainsKey(minion.instanceId) == false)
                    minions.Add(minion.instanceId, minion);

            toBeAddedMinions.Clear();
            toBeRemovedMinions.Clear();
        }

        private void stepMovement()
        {
            if (boardState == BoardState.MOVING)
            {
                float currentDistance = (targetPosition - position).magnitude;
                float stepPos = (targetPosition - startPosition).magnitude/totalAnimationTime*Chronos.deltaTime;
                float stepRot = (targetRotation - startRotation).magnitude/totalAnimationTime*Chronos.deltaTime;

                if (currentDistance <= stepPos)
                {
                    position = targetPosition;
                    rotation = targetRotation;
                    boardState = BoardState.NORMAL;
                }
                else
                {
                    position += (targetPosition - position).normalized*stepPos;
                    rotation += (targetRotation - rotation).normalized*stepRot;
                }

            }
        }
        /// <summary>
        /// Verilen minionu boarda ekler. Default olarak minion board'un path'inin ilk noktasina yerlestirilir.
        /// </summary>
        /// <param name="minion">boarda yerlestirilecek minion</param>
        /// <param name="addToEnd">eger bu deger true ise minion board un pathinin son noktasina yerlestirilir (geri yonde ilerleyen minionlar icin).</param>
        /// <returns>Bu islem her zaman basarili oldugu icin bir return degeri yoktur.</returns>
        public void AddMinion(Minion minion, bool addToEnd = false, bool tellUsers = true)
        {
            if (boardState != BoardState.COLLAPSING)
            {
                try
                {
                    toBeAddedMinions.Add(minion);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace + " : " + e.Message);
                }

                if (minion.position == null)
                    minion.position = new MinionPosition();
                minion.position.board = this;

                if (!addToEnd)
                    minion.position.pathPosition = getPath().getStartPoint();
                else
                    minion.position.pathPosition = getPath().getEndPoint();

                if(tellUsers)
                    Messages.OutgoingMessages.Game.GMinionPositionInfo.sendMessage(player.game.players,minion);
            }
            else
            {
                minion.destroyable = true;
                Messages.OutgoingMessages.Game.GDestroyMinionInfo.sendMessage(player.game.players,minion);
            }

        }


        /// <summary>
        /// Verilen minionu boarda ekler. 2.Parametrede verilen noktaya goturur.
        /// </summary>
        /// <param name="minion">boarda yerlestirilecek minion</param>
        /// <returns>Bu islem her zaman basarili oldugu icin bir return degeri yoktur.</returns>
        public void AddMinionSpecificPosition(Minion minion, PathPosition position, bool notifyPlayers = true)
        {
            if (boardState != BoardState.COLLAPSING)
            {
                try
                {
                    toBeAddedMinions.Add(minion);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace + " : " + e.Message);
                }

                if (minion.position == null)
                    minion.position = new MinionPosition();

                minion.position.board = this;
                minion.position.pathPosition = new PathPosition(position.pointIndex, position.ratio);
                
                if(notifyPlayers)
                    Messages.OutgoingMessages.Game.GMinionPositionInfo.sendMessage(player.game.players, minion);
            }
            else
            {
                minion.destroyable = true;
                Messages.OutgoingMessages.Game.GDestroyMinionInfo.sendMessage(player.game.players, minion);
            }

        }

        /// <summary>
        /// verilen minion'un position.board elemanini 'null'a esitler. Bu minionu iceren liste, iteration sirasinda bu durumu farkedip minionu listeden silecektir.
        /// </summary>
        /// <param name="minion">board'dan cikarilacak minion</param>
        public void RemoveMinion(Minion minion)
        {
            minion.position.board = null;       // burada hashmap uzerinde herhangi bir islem yapmiyoruz. aksi takdirde minionlari gezen foreach iteration'ini bozabiliriz. bu minion daha sonra iteration tarafindan tespit edilip listeden silinecek, sadece board'i null yapmak yeterli.
        }

        /// <summary>
        /// Verilen kuleyi indexi verilen towerSlot a yerlestirir. Oyunculari bu durumdan haberdar "etmez"!
        /// </summary>
        /// <param name="tower">board'a yerlestirilecek kule</param>
        /// <param name="slotIndex">kulenin yerlestirilecegi slotun indexi</param>
        /// <returns>Verilen slot indexin, towerSlots index araliginin disinda olmasi durumunda false return eder. Diger her durum icin return 'true'dur.</returns>
        public bool AddTower(Tower tower, int slotIndex)
        {
            if (slotIndex >= 0 && slotIndex < towers.Length)
            {
                towers[slotIndex] = tower;
                tower.board = this;
                tower.indexOnBoard = slotIndex;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verilen kuleyi board'dan siler. Oyunculari bu durumdan haberdar "etmez"!
        /// </summary>
        /// <param name="tower">board'dan silinecek kule</param>
        /// <returns>Verilen kulenin indexOnBoard degeri, towerSlots index araliginin disinda olmasi durumunda false return eder.
        /// Verilen kulenin, indexOnBoard ile belirtilen konumda bulunmamasi durumunda false return eder (Bu konumda boyle bir kule yok!). Diger her durum icin return 'true'dur.</returns>
        public bool RemoveTower(Tower tower)
        {
            int slotIndex = tower.indexOnBoard;

            if (slotIndex > 0 && slotIndex < towers.Length && towers[slotIndex] == tower)
            {
                towers[slotIndex] = null;
                return true;
            }
            return false;
        }

        public abstract void loadResources();
        public abstract IPath getPath();                    // return ettigi path static olmali, o classin butun instance larinda ayni olmali.
        public abstract TowerSlots getTowerSlots();         // return ettigi towerSlots static olmali, o classin butun instance larinda ayni olmali.

        public void destroyMinionsOnBoard()
        {
            foreach (var minion in minions)
            {
                minion.Value.destroyable = true;
                Messages.OutgoingMessages.Game.GDestroyMinionInfo.sendMessage(player.game.players,minion.Value);
            }
        }

        public void destroyTowersOnBoard()
        {
            foreach (var tower in towers)
            {
                if (tower != null)
                {
                    tower.destroyable = true;
                    Messages.OutgoingMessages.Game.GDestroyTowerInfo.sendMessage(player.game.players,tower);
                }
            }
        }
    }
}
