using System;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Scripts.Engine.AreaEffects;
using Assets.Scripts.Engine.Helpers;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Missiles;
using NetWorker.Utilities;
using UnityEngine;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.Engine.Statistics;


namespace Assets.Scripts.Engine
{
    public static class Game
    {
        public static LinkedList<Player> players = new LinkedList<Player>();
		public static List<Player> statPlayers = new List<Player> ();
        private static LinkedList<AreaEffect> areaEffects = new LinkedList<AreaEffect>();
        private static LinkedList<Missile> missiles =new LinkedList<Missile>();

        public static float nextPaymentTime;
        public static float nextRandomMinionTime;
        public static float gameTime;
        public static float pauseTime;
        public enum GameState
        {
            READYWAIT,
            LOADING,
            STARTCOUNTDOWN,
            PLAYTIME,
            ANIMATIONWAIT,
            ENDGAME
        };

		public static StatTracker statTracker;

        public static GameState gameState = GameState.READYWAIT;

        public static void step()
        {
			//gameState == GameState.PLAYTIME)
            stepTimers();

            checkStartCountDownEnded();
            
            

			if (gameState == GameState.PLAYTIME)
			{
                restoreMinionAndTowerStats();
				stepMissiles();
				stepAreaEffects();
				stepPlayers();

                checkBoardDestruction();
                checkGameEnded();
			}

			if (gameState == GameState.ANIMATIONWAIT)
			{
				//sadece boardGUI steplesin ki ekrandaki hareketi gostersin istiyoruz.
				// Daha sonra mantikli olup olmadi[i konusunda tartis.
				foreach (Player p in players)
				{
					p.board.step ();
					if (p.board.tag != null)
						p.board.tag.step();
				}

				checkBoardDestructionEnded();
			}
        }


        #region State Changers

        public static void setState(GameState state)
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
                    setStateReadyWait(); break;
                case GameState.LOADING:
                    setStateLoading(); break;
                case GameState.STARTCOUNTDOWN:
                    setStateStartCountDown(); break;
                case GameState.PLAYTIME:
                    setStatePlayTime(); break;
                case GameState.ANIMATIONWAIT:
                    setStateAnimationWait(); break;
                case GameState.ENDGAME:
                    setStateEndGame(); break;
            }

            gameState = state;
        }

        #region SETS

        public static void setStateReadyWait()
        {
            
        }
        public static void setStateLoading()
        {
            Runner.Graphics.loadGame();
        }
        public static void setStateStartCountDown()
        {

        }
        public static void setStatePlayTime()
        {

        }
        public static void setStateAnimationWait()
        {
        }
        public static void setStateEndGame()
        {
            
        }

        #endregion

        #region QUITS

        public static void quitStateReadyWait()
        {

        }
        public static void quitStateLoading()
        {

        }
        public static void quitStateStartCountDown()
        {
            
        }
        public static void quitStatePlayTime()
        {

        }
        public static void quitStateAnimationWait()
        {
			Runner.Graphics.quitGameState(GameState.ANIMATIONWAIT);
        }
        public static void quitStateEndGame()
        {

        }

        #endregion

        #endregion


        #region Steps

        private static void stepTimers()
        {
            if (pauseTime > 0)
                pauseTime -= Chronos.deltaTime;

            if (gameState == GameState.PLAYTIME)
            {
                gameTime += Chronos.deltaTime;

                if (nextPaymentTime > 0)
                    nextPaymentTime -= Chronos.deltaTime;
                if (nextRandomMinionTime > 0)
                    nextRandomMinionTime -= Chronos.deltaTime;
            }
        }

        private static void stepMissiles()
        {
            LinkedListNode<Missile> missileNode = missiles.First;
            LinkedListNode<Missile> tmpNode;

            while (missileNode != null)
            {
                if (missileNode.Value.destroyable)
                {
                    tmpNode = missileNode;
                    missileNode = missileNode.Next;
                    missiles.Remove(tmpNode);					
                }
                else
                {
                    missileNode.Value.step();
                    missileNode = missileNode.Next;
                }
            }
        }

        private static void stepAreaEffects()
        {
            LinkedListNode<AreaEffect> areaEffectNode = areaEffects.First;
            LinkedListNode<AreaEffect> tmpNode;

            while (areaEffectNode != null)
            {
                if (areaEffectNode.Value.destroyable)
                {
                    tmpNode = areaEffectNode;
                    areaEffectNode = areaEffectNode.Next;
                    areaEffects.Remove(tmpNode);
                }
                else
                {
                    areaEffectNode.Value.step();
                    areaEffectNode = areaEffectNode.Next;
                }
            }
        }

        private static void stepPlayers()
        {
            LinkedListNode<Player> playerNode = players.First;
            LinkedListNode<Player> tmpNode;

            while (playerNode != null)
            {
                if (playerNode.Value.destroyable)
                {
                    tmpNode = playerNode;         // playeri silersek silinen board uzerinde minion instance id ile arama yapamiyoruz, aradigimiz minionlari bulamiyoruz.
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

        private static void restoreMinionAndTowerStats()
        {
            LinkedListNode<Player> playerNode = players.First;
            LinkedListNode<Player> tmpNode;

            while (playerNode != null)
            {
                if (playerNode.Value.destroyable)
                {
                    tmpNode = playerNode;         // playeri silersek silinen board uzerinde minion instance id ile arama yapamiyoruz, aradigimiz minionlari bulamiyoruz.
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

        #region Timed Events

        private static void checkStartCountDownEnded()
        {
            if (gameState == GameState.STARTCOUNTDOWN && pauseTime <= 0)
                setState(GameState.PLAYTIME);
        }


        #endregion
        
		public static User getUserById(int id)
		{
			foreach( Player p in players)
			{
				if(p.user.id == id)
					return p.user;
			}
			return null;
		}
    
		public static Board getBoardById(int instanceId)
		{
			foreach( Player p in players)
			{
				if(p.board.instanceId == instanceId)
					return p.board;
			}
			return null;
		}

        public static Minion getMinionById(int instanceId)
        {
            Minion result;
            foreach (Player p in players)
            {
                if (p.board.minions.TryGetValue(instanceId, out result))
                    if( result != null)
                        return result;

                foreach (Minion minion in p.board.toBeAddedMinions)
                    if (minion.instanceId == instanceId)
                        return minion;

            }
            return null;
        }

		#region helpers

		public static float calculateBoardDistanceToCenter(int userCount) { 

			if(userCount == 1)
				return 0;

			float a = 2 * Mathf.PI / userCount;
			float d2 = 100.0f/(1-Mathf.Cos(a));
			float l2 = 200.0f - 100.0f * Mathf.Sqrt(2);
			float theta = 0.3927f;
			return Mathf.Sqrt(d2 + l2 - 2 * Mathf.Sqrt (d2) * Mathf.Sqrt(l2) * Mathf.Cos(Mathf.PI/2 - a/2 + theta)); 
		}


		#endregion


        public static void AddMissile(Missile misile)
        {
            missiles.AddLast(misile);
        }

        public static void AddAreaEffect(AreaEffect areaEffect)
        {
            areaEffects.AddLast(areaEffect);
        }

        public static void setPaymentTime(float nextPaymentTime)
        {
            Game.nextPaymentTime = nextPaymentTime;
            Runner.Graphics.updateNextPaymentTime();
        }

        public static void setRandomMinionTime(float randomMinionTime)
        {
            nextRandomMinionTime = randomMinionTime;
            Runner.Graphics.updateNextRandomMinionTime();
        }

        public static void setPlayerHealth(Player player, int newHealthAmount)
        {
            player.healthPoints = newHealthAmount;
            Runner.Graphics.updatePlayerHealth(player);
        }

        public static void checkBoardDestruction()
        {
            foreach (var player in players)
            {
                Board board = player.board;
                if (player.playerState == Player.PlayerState.DEAD && board.boardState != Board.BoardState.COLLAPSING && board.boardState != Board.BoardState.COLLAPSED)
                {
                    int index = 0, maxPlayerCount = 0;

                    foreach (var p in players)
                        if (p.playerState == Player.PlayerState.ALIVE)
                            maxPlayerCount++;

                    if (maxPlayerCount < 2) // sahnede kalacak board sayisi 2 den az olamaz.
                        break;

					Game.setState(GameState.ANIMATIONWAIT);
                    board.boardState = Board.BoardState.COLLAPSING; // setleme isini burada yaptik cunku break'le bu donguden cikma ihtimalimiz var. eger yukarda setlemis olsaydik geri almak zorunda kalacaktik.

                    foreach (var p in players)
                        if (p.playerState == Player.PlayerState.ALIVE)
                        {
                            Board b = p.board;
                            b.boardState = Board.BoardState.MOVING;
                            b.startPosition = new Vector3(b.position.x, b.position.y, b.position.z);
                            b.startRotation = new Vector3(b.rotation.x, b.rotation.y, b.rotation.z);

                            float distance = calculateBoardDistanceToCenter(maxPlayerCount);
                            Vector3 rotation = new Vector3(0, index * 360.0f / maxPlayerCount, 0);
                            b.targetRotation = rotation;
                            b.targetPosition = new Vector3((float)Math.Cos(-1 * rotation.y * (Math.PI / 180.0)) * distance, 0, (float)(Math.Sin(-1 * rotation.y * (Math.PI / 180.0)) * distance));

                            index++;
                        }
                }
            }
        }

		public static void checkBoardDestructionEnded()
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

        public static void checkGameEnded()
        {
            int aliveCount = 0;
            foreach (var player in players)
            {
                if (player.healthPoints > 0)
                    aliveCount++;
            }

            if (aliveCount == 1)
            {
                // you won the game
                // lost condition is handled in Player step().
                setState(GameState.ENDGAME);
				Assets.Scripts.Engine.Messages.OutgoingMessages.Game.GEndGameStatisticsRequest.sendMessage();
            }
        }

        public static void clearOldGameData()
        {
            missiles = new LinkedList<Missile>();
            areaEffects = new LinkedList<AreaEffect>();
            nextPaymentTime = 0;
            nextRandomMinionTime = 0;
            gameTime = 0;
            pauseTime = 0;
            gameState = GameState.READYWAIT;
        }
  
    }
}
