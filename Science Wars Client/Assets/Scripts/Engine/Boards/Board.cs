using System.Collections.Generic;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Helpers;
using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Paths;
using Assets.Scripts.Engine.ResourceManager;
using Assets.Scripts.Engine.Towers;
using UnityEngine;
using System;

namespace Assets.Scripts.Engine
{
    public abstract class Board : IRequiresResource
    {
		public int instanceId;

        public IStep tag;

        public Vector3 position;
        public Vector3 rotation;

        public Player player;
        public Dictionary<int, Minion> minions = new Dictionary<int, Minion>();
        public Tower[] towers;

        public Board nextBoard;
        public Board prevBoard;

        public ScienceType scienceType;

        #region MinionList Modifiers

        List<Minion> toBeRemovedMinions = new List<Minion>();
        public List<Minion> toBeAddedMinions = new List<Minion>();

        #endregion

        #region Destruction Animation
        public enum BoardState { NORMAL, MOVING, COLLAPSING, COLLAPSED }
        public BoardState boardState = BoardState.NORMAL;
        public Vector3 startPosition;
        public Vector3 startRotation;
        public Vector3 targetPosition;
        public Vector3 targetRotation;
        private float totalAnimationTime = 5f;  // animasyonun 5 saniyede tamamlanmasini istiyoruz.
        #endregion

        public void step()
        {            
			stepMinions();
			stepTowers();       // gui resetlensin diye if'in disina aldim. buralari duzgun yazmak lazim.
        	stepMovement();
        }

        private void stepTowers()
        {
            for (int i = 0; i < towers.Length; i++)
            {
                if (towers[i] != null)
                {
                    if (towers[i].destroyable)
                    {
                        towers[i] = null;
                    }
                    else
                    {
						if (Game.gameState == Game.GameState.PLAYTIME)
                        	towers[i].step();
                    }
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
                    {
						if (Game.gameState == Game.GameState.PLAYTIME)
                        	minion.Value.step();
                    }
                }
            }

			foreach(Minion m in toBeRemovedMinions)
                if( minions.ContainsKey(m.instanceId))
				    minions.Remove(m.instanceId);

            toBeRemovedMinions.Clear();

            foreach (Minion minion in toBeAddedMinions)
                if (minions.ContainsKey(minion.instanceId) == false)
                    minions.Add(minion.instanceId, minion);

            toBeAddedMinions.Clear();
        }
        private void stepMovement()
        {
            if (boardState == BoardState.MOVING)
            {
                float currentDistance = (targetPosition - position).magnitude;
                float stepPos = (targetPosition - startPosition).magnitude / totalAnimationTime * Chronos.deltaTime;
                float stepRot = (targetRotation - startRotation).magnitude / totalAnimationTime * Chronos.deltaTime;

                if (currentDistance <= stepPos)
                {
                    position = targetPosition;
                    rotation = targetRotation;
                    boardState = BoardState.NORMAL;
                }
                else
                {
                    position += (targetPosition - position).normalized * stepPos;
                    rotation += (targetRotation - rotation).normalized * stepRot;
                }

            }
        }
      
        /// <summary>
        /// Verilen minionu boarda ekler.
        /// </summary>        
        public void AddMinion(Minion minion)
        {			
            toBeAddedMinions.Add(minion);
			//minions.Add(minion.instanceId, minion);
			minion.position.board = this;
        }

        public void AddMinionSpecificPosition(Minion minion, PathPosition position)
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
        /// Verilen kuleyi indexi verilen towerSlot a yerlestirir.
        /// </summary>
        /// <param name="tower">board'a yerlestirilecek kule</param>
        /// <param name="slotIndex">kulenin yerlestirilecegi slotun indexi</param>
        /// <returns>Verilen slot indexin, towerSlots index araliginin disinda olmasi durumunda false return eder.</returns>
        public bool AddTower(Tower tower, int slotIndex)
        {
            if (slotIndex >= 0 && slotIndex < towers.Length)
            {
				if(PlayerMe.self.id == this.player.id)
				{
					if(PlayerMe.cash >= tower.getCost())
					{
						PlayerMe.cash -= tower.getCost();
						Runner.Graphics.updateCashAndIncome();
					}
					//else					comment'e aldim cunku: server kuleyi ekle diyor, clienttaki para belki yanlistir bilmiyoruz ki. neden parasi yoksa eklemiyoruz anlamadim.
						//return false;
				}
                towers[slotIndex] = tower;
				tower.board = this;
                tower.indexOnBoard = slotIndex;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verilen kuleyi board'dan siler.
        /// </summary>
        /// <param name="tower">board'dan silinecek kule</param>
        /// <returns>Verilen kulenin indexOnBoard degeri, towerSlots index araliginin disinda olmasi durumunda false return eder.
        /// Verilen kulenin, indexOnBoard ile belirtilen konumda bulunmamasi durumunda false return eder (Bu konumda boyle bir kule yok!). Diger her durum icin return 'true'dur.</returns>
        /// <remarks>Eger tower oyundan tamamen silinecekse (bu remove fonksiyonundan sonra baska bir boardda kullanilmayacaksa) bu fonksiyonla birlikte tower.destroyable = true; islemini yapmayi unutmayin</remarks>
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

		public Vector3 getTowerPosition(int indexOnBoard)
		{
			Vector3 point = getTowerSlots().positions[indexOnBoard];
			
			float posX = point.x * Mathf.Cos(Mathf.Deg2Rad * rotation.y*-1) - point.z * Mathf.Sin(Mathf.Deg2Rad * rotation.y*-1);
			float posZ = point.x * Mathf.Sin(Mathf.Deg2Rad * rotation.y*-1) + point.z * Mathf.Cos(Mathf.Deg2Rad * rotation.y*-1);
			
			return new Vector3(posX, point.y, posZ) + position;
		}
    }
}
