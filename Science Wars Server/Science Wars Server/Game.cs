using System;
using System.Collections.Generic;
using Science_Wars_Server.AreaEffects;
using Science_Wars_Server.Boards;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Minions.Physics;
using Science_Wars_Server.Missiles;
using Science_Wars_Server.Towers;
using Science_Wars_Server.Statistics;

namespace Science_Wars_Server
{
    public class Game
    {
        public bool destroyable;

        float readyStateEndTime;
        float loadingStateEndTime;

        public float nextPaymentTime = PAYMENT_TIME_DEFAULT;
        float gameTime;
        float pauseTime;
        public float nextRandomMinionTime = RANDOM_MINION_TIME_DEFAULT;

        public LinkedList<Player> players = new LinkedList<Player>();
        public List<Player> statPlayers = new List<Player>();
        public Dictionary<int, AreaEffect> areaEffects = new Dictionary<int, AreaEffect>();
        public Dictionary<int, Missile> missiles = new Dictionary<int, Missile>();

        public int remainingPlayerCount = 0; // kac kisi cikti? hepsi ciktiysa destroy.

        public int remainingRandomMinionCount = 0;
        public float remainingRandomMinionSpawnTime = 0;
        public bool currentlySpawning = false;

        public StatTracker statTracker;

        public enum GameState
        {
            READYWAIT,
            LOADING,
            STARTCOUNTDOWN,
            PLAYTIME,
            ANIMATIONWAIT,
            ENDGAME
        };

        public GameState gameState  = GameState.READYWAIT;

        #region Static Initials

        public static float READY_STATE_END_TIME_DEFAULT = 15.0f;  //15 saniye boyunca kullanicinin queueRequest gondermesini bekle.
        private static float LOADING_STATE_END_TIME_DEFAULT = 60.0f; // 60 saniye kadar oyuncularin oyunu yuklemesini(GLoadingStateResult) bekle. 
        public  static float START_COUNTDOWN_TIME_DEFAULT = 5.0f; // her oyun acilista 5 saniye bekletecek.
        private static float ANIMATION_WAIT_TIME_DEFAULT = 5.0f; // board yikilma animasyonu 5 saniye bekletecek.
        private static float PAYMENT_TIME_DEFAULT = 7.0f; // her odeme 7 saniyede 1 yapilacak.
        private static float RANDOM_MINION_TIME_DEFAULT = 45.0f; // her 12 saniyede 1 random minion gonderilecek yapilacak.
        private static float RANDOM_MINION_TIME_BETWEEN_EACH_MINION = .5f; // cikan minionlar yarim saniye aralikli olacak.

        #endregion

        /// <summary>
        /// Userlari kullanarak playerlar olusturur. Bu userlar icin setState(GAME) fonksiyonunu cagirir.
        /// GameState i ReadyWait e setler.
        /// </summary>
        /// <param name="users"></param>
        public Game(List<User> users)   // her player in kullanacagi board i da almamiz gerek. ya da bu bilgiyi user dan cekebiliriz.   TODO
        {
            foreach (User user in users)
            {
                Player pTemp = new Player(user, this );
                players.AddLast(pTemp);
                statPlayers.Add(pTemp);
                user.player = pTemp;
            }

            remainingPlayerCount += users.Count;

            float distance = calculateBoardDistanceToCenter(users.Count);

            for (int i=0; i<users.Count; i++)
            {
                Vector3 rotation = new Vector3(0, i * 360.0f / users.Count, 0);
                users[i].player.board.rotation = rotation;
                users[i].player.board.position = new Vector3((float)Math.Cos(-1*rotation.y * (Math.PI / 180.0)) * distance, 0, (float) (Math.Sin(-1*rotation.y * (Math.PI / 180.0)) * distance));
                users[i].player.board.nextBoard = users[(i + 1)%users.Count].player.board;
                users[i].player.board.prevBoard = users[(i + users.Count - 1) % users.Count].player.board;
            }

            this.statTracker = new StatTracker(this);

            setStateReadyWait();
        }

        public void step()
        {
            stepTimers();

            checkStartCountDownEnded();
            checkReadyQueueEnded();
            checkLoadingStateEndTime();

            if (gameState == GameState.PLAYTIME && pauseTime <= 0)
            {
                restoreMinionAndTowerStats();
                stepMissiles();
                stepAreaEffects();
                stepPlayers();

                checkPaymentTime();
                checkRandomMinionTime();
                checkBoardDestruction();
                checkGameEnded();
                checkDisconnectedPlayers();
            }

            if (gameState == GameState.ANIMATIONWAIT)
            {
                foreach (Player p in players)
                    p.board.step(); // board'lar hareket etmeye devam etsin, yikilan board'un yeri doldurulsun.

                checkBoardDestructionEnded();
            }

            if( remainingPlayerCount == 0)
                destroy();
        }


        #region Step Helpers

        private void stepMissiles()
        {
            List<Missile> toBeDestroyed = new List<Missile>();

            foreach (var missile in missiles)
            {
                if (missile.Value != null)
                {
                    if (missile.Value.destroyable)
                        toBeDestroyed.Add(missile.Value);
                    else
                        missile.Value.step();
                }
            }

            foreach (var missile in toBeDestroyed)
            {
                missiles.Remove(missile.instanceId);
            }
        }
        private void stepAreaEffects()
        {
            List<AreaEffect> toBeDestroyed = new List<AreaEffect>();

            foreach (var key in areaEffects.Keys)
            {
                if (areaEffects[key] != null)
                {
                    if (areaEffects[key].destroyable)
                        toBeDestroyed.Add(areaEffects[key]);
                    else
                        areaEffects[key].step();
                }
            }

            foreach (var areaEffect in toBeDestroyed)
                areaEffects.Remove(areaEffect.instanceId);
        }
        private void stepPlayers()
        {
            LinkedListNode<Player> playerNode = players.First;
            LinkedListNode<Player> tmpNode;

            while (playerNode != null)
            {
                if (playerNode.Value.destroyable)
                {
                    tmpNode = playerNode;
                    playerNode = playerNode.Next;
                    players.Remove(tmpNode);
                }
                else
                {
                    playerNode.Value.step();
                    playerNode = playerNode.Next;
                }
            }
        }

        private void stepTimers()
        {
            readyStateEndTime -= Chronos.deltaTime;
            loadingStateEndTime -= Chronos.deltaTime;

            if (pauseTime > 0)
                pauseTime -= Chronos.deltaTime;
            
            if (gameState == GameState.PLAYTIME)
            {
                gameTime += Chronos.deltaTime;
                if (nextPaymentTime > 0)
                    nextPaymentTime -= Chronos.deltaTime;
                if (currentlySpawning == false && nextRandomMinionTime > 0)
                    nextRandomMinionTime -= Chronos.deltaTime;
            }
        }

        private void restoreMinionAndTowerStats()
        {
            LinkedListNode<Player> playerNode = players.First;
            LinkedListNode<Player> tmpNode;

            while (playerNode != null)
            {
                if (playerNode.Value.destroyable)
                {
                    tmpNode = playerNode;
                    playerNode = playerNode.Next;
                    players.Remove(tmpNode);
                }
                else
                {
                    foreach (var minion in playerNode.Value.board.minions)
                    {
                        minion.Value.stats.restore();
                    }
                    foreach (Tower tower in playerNode.Value.board.towers)
                    {
                        if(tower != null)
                            tower.stats.restore();
                    }
                    playerNode = playerNode.Next;
                }
            }
        }

        #endregion

        #region State Changers
        
        public void setState(GameState state)
        {
            switch (gameState)                  // Onceki state i terket.
            {
                case GameState.READYWAIT:
                    quitStateReadyWait(); break;
                case GameState.LOADING:
                    quitStateLoading(); break;
                case GameState.STARTCOUNTDOWN:
                    quitStateStartCountDown(); break;
                case GameState.PLAYTIME:
                    quitStatePlayTime(); break;
                case GameState.ANIMATIONWAIT:
                    quitStateAnimationWait(); break;
                case GameState.ENDGAME:
                    quitStateEndGame(); break;
            }

            switch (state)                      // yeni state e gir.
            {
                    case GameState.READYWAIT:
                        setStateReadyWait();    break;
                    case GameState.LOADING:
                        setStateLoading();  break;
                    case GameState.STARTCOUNTDOWN:
                        setStateStartCountDown();   break;
                    case GameState.PLAYTIME:
                        setStatePlayTime(); break;
                    case GameState.ANIMATIONWAIT:
                        setStateAnimationWait();    break;
                    case GameState.ENDGAME:
                        setStateEndGame();  break;
            }

            gameState = state;
        }

        #region SETS
        
        public void setStateReadyWait()
        {
            readyStateEndTime = READY_STATE_END_TIME_DEFAULT;

            Messages.OutgoingMessages.Game.GReadyStateRequest.sendMessage(players);

            foreach (var player in players)
                player.user.setState(User.UserState.GAME);
        }
        public void setStateLoading()
        {
            loadingStateEndTime = LOADING_STATE_END_TIME_DEFAULT;

            Messages.OutgoingMessages.Game.GLoadingStateRequest.sendMessage(players);
        }

        public void setStateStartCountDown()
        {
            pauseTime = START_COUNTDOWN_TIME_DEFAULT;
            Messages.OutgoingMessages.Game.GEnterStartCountdown.sendMessage(players, START_COUNTDOWN_TIME_DEFAULT);
        }

        public void setStatePlayTime()
        {

        }
        public void setStateAnimationWait()
        {
            pauseTime = ANIMATION_WAIT_TIME_DEFAULT;
            // TODO MSG AnimationWait bilgisini userlara gonder
        }
        public void setStateEndGame()
        {
            // TODO MSG userlara oyunun bittigini soyle. istatistikleri gondermiyoruz cunku her client istatistik verisini kendisi hesapliyor.
        }
        
        #endregion

        #region QUITS

        public void quitStateReadyWait()
        {
            
        }
        public void quitStateLoading()
        {
            
        }
        public void quitStateStartCountDown()
        {
            Messages.OutgoingMessages.Game.GRandomMinionTimeInfo.sendMessage( players );
            Messages.OutgoingMessages.Game.GPaymentTimeInfo.sendMessage( players, nextPaymentTime);
        }
        public void quitStatePlayTime()
        {

        }
        public void quitStateAnimationWait()
        {

        }
        public void quitStateEndGame()
        {
            
        }

        #endregion

        #endregion

        #region Timed Events

        private void checkRandomMinionTime()
        {
            if (currentlySpawning)
            {
                nextRandomMinionTime -= Chronos.deltaTime;

                if (nextRandomMinionTime <= 0)
                {
                    nextRandomMinionTime = RANDOM_MINION_TIME_BETWEEN_EACH_MINION;
                    remainingRandomMinionCount--;

                    // ne tur minionlar spawnlayabilecegine karar vermek lazim. suanda random, kullanicilarin yapmasi mumkun olmayanlar bile cikabiliyor.
                    // mesela frankenscienist dev minion da cikabilir.
                    Type nextType = TypeIdGenerator.getMinionType(RandomNumberProvider.random.Next(TypeIdGenerator.getMinionTypeCount()));
                    Minion newSpawn;

                    foreach (var player in  players)
                    {
                        if ( player.playerState == Player.PlayerState.ALIVE )
                        {
                            newSpawn = (Minion)Activator.CreateInstance(nextType, this, null);
                            player.board.AddMinion(newSpawn);
                            Messages.OutgoingMessages.Game.GCreateMinionResult.sendMessage(players, newSpawn);
                        }

                    }
                    if (remainingRandomMinionCount == 0)
                    {
                        currentlySpawning = false;
                        nextRandomMinionTime = RANDOM_MINION_TIME_DEFAULT;
                        Messages.OutgoingMessages.Game.GRandomMinionTimeInfo.sendMessage(players);
                    }
                }
            }
            else if (nextRandomMinionTime <= 0)
            {
                remainingRandomMinionCount = RandomNumberProvider.random.Next(3, 4);
                currentlySpawning = true;
            }
        }

        private void checkPaymentTime()
        {
            if (nextPaymentTime <= 0)
            {
                payPlayersTheirIncome();
                nextPaymentTime = PAYMENT_TIME_DEFAULT;
                Messages.OutgoingMessages.Game.GPaymentTimeInfo.sendMessage(players, nextPaymentTime);
            }
        }

        private void checkStartCountDownEnded()
        {
            if (gameState == GameState.STARTCOUNTDOWN && pauseTime <= 0)
                setState(GameState.PLAYTIME);
        }

        private void checkReadyQueueEnded()
        {
            if (gameState == GameState.READYWAIT && readyStateEndTime <= 0)
            {
                foreach (Player player in players)
                {
                    if (player.readyInQueue)
                    {
                        player.user.setState(User.UserState.LOBBY);
                        Runner.queue.addUser(player.user);
                    }
                    else
                        player.user.setState(User.UserState.LOBBY);
                }

                destroy();
            }
        }

        private void checkLoadingStateEndTime()
        {
            if (gameState == GameState.LOADING && loadingStateEndTime <= 0)
            {
                foreach (Player player in players)
                {
                    if (player.loadedTheGame)
                    {
                        player.user.setState(User.UserState.LOBBY);
                        Runner.queue.addUser(player.user);
                    }
                    else
                        player.user.setState(User.UserState.LOBBY);
                }

                destroy();
            }
        }

        #endregion

        #region helpers

        private float calculateBoardDistanceToCenter(int userCount)
        {
            if (userCount == 1)
                return 0f;

            double a = 2 * Math.PI / userCount;
            double d2 = 100.0 / (1 - Math.Cos(a));
            double l2 = 200.0 - 100.0f * Math.Sqrt(2);
            double theta = 0.3927;
            return (float) Math.Sqrt(d2 + l2 - 2 * Math.Sqrt(d2) * Math.Sqrt(l2) * Math.Cos(Math.PI / 2 - a / 2 + theta));
        }

        #endregion

        public void destroy()
        {
            destroyable = true;
        }

        public void addMissile( Missile missile )
        {
            if( missiles.ContainsKey(missile.instanceId) == false)
                missiles.Add(missile.instanceId, missile);
            Messages.OutgoingMessages.Game.GCreateMissileInfo.sendMessage(players, missile);
        }

        public void addAreaEffect(AreaEffect areaEffect)
        {
            areaEffects.Add( areaEffect.instanceId, areaEffect);           

            // removeAreaEffect fonksiyonu gereksiz cunku areaEffect.destroyable==true oldugu zaman oyun bu areaEffect'i zaten silecek.
        }

        public void payPlayersTheirIncome()
        {
            foreach (var player in players)
            {
                if (player.playerState == Player.PlayerState.ALIVE)
                {
                    player.addCash(player.income);
                    Messages.OutgoingMessages.Game.GCashAndIncomeInfo.sendMessage(player);
                }
            }
        }

        public void checkBoardDestruction()
        {
            foreach (var player in players)
            {
                Board board = player.board;
                if (player.playerState == Player.PlayerState.DEAD && board.boardState != Board.BoardState.COLLAPSING && board.boardState != Board.BoardState.COLLAPSED)
                {
                    int index = 0, maxPlayerCount=0;

                    foreach (var p in players)
                        if (p.playerState == Player.PlayerState.ALIVE)
                            maxPlayerCount ++;

                    if (maxPlayerCount < 2) // sahnede kalacak board sayisi 2 den az olamaz.
                        break;

                    setState(GameState.ANIMATIONWAIT);
                    board.boardState = Board.BoardState.COLLAPSING; // setleme isini burada yaptik cunku break'le bu donguden cikma ihtimalimiz var. eger yukarda setlemis olsaydik geri almak zorunda kalacaktik.
                    board.destroyMinionsOnBoard();
                    board.destroyTowersOnBoard();

                    foreach (var p in players)
                        if (p.playerState == Player.PlayerState.ALIVE)
                        {
                            Board b = p.board;
                            b.boardState = Board.BoardState.MOVING;
                            b.startPosition = new Vector3(b.position);
                            b.startRotation = new Vector3(b.rotation);

                            float distance = calculateBoardDistanceToCenter(maxPlayerCount);
                            Vector3 rotation = new Vector3(0, index * 360.0f / maxPlayerCount, 0);
                            b.targetRotation = rotation;
                            b.targetPosition = new Vector3((float)Math.Cos(-1 * rotation.y * (Math.PI / 180.0)) * distance, 0, (float)(Math.Sin(-1 * rotation.y * (Math.PI / 180.0)) * distance));

                            index++;
                        }

                }
            }
        }

        public void checkBoardDestructionEnded()
        {
            bool allMovementEnded = true;

            foreach (var player in players)
            {
                if (player.board.boardState == Board.BoardState.MOVING)
                {
                    allMovementEnded = false;
                    break;
                }
            }

            if (allMovementEnded)
            {
                foreach (var player in players)
                {

                    if (player.playerState == Player.PlayerState.DEAD &&
                        player.board.boardState == Board.BoardState.COLLAPSING)
                    {
                        player.board.prevBoard.nextBoard = player.board.nextBoard;
                        player.board.nextBoard.prevBoard = player.board.prevBoard;
                        player.board.boardState = Board.BoardState.COLLAPSED;
                    }

                }
                setState(GameState.PLAYTIME);
            }

            
        }

        public void checkGameEnded()
        {
            int aliveCount = 0;
            foreach (var player in players)
            {
                if (player.healthPoints > 0)
                    aliveCount++;
            }

            if (aliveCount < 2)
            {
                setState( GameState.ENDGAME);
            }
        }

        public void checkDisconnectedPlayers()
        {
            foreach (var user in players)
            {
                if(user.playerState != Player.PlayerState.DEAD && user.user.Destroyable)    // disconnect olmuş ama ölü olmayan playerlar
                    user.decreaseHealth(user.healthPoints);
            }
        }

        public void removePlayer(Player player)
        {
            player.decreaseHealth( player.healthPoints );
            player.user.setState(User.UserState.LOBBY);
            remainingPlayerCount--;
        }
    
    }
}
