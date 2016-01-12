using System.Collections;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Messages.OutgoingMessages.Lobby;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.GUI.GUIUtilities;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.GUI.SceneSpecific.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GUI.Graphics
{
    public partial class Graphics : MonoBehaviour, Engine.IGUI.IGraphics
    {
        #region Graphics State

        public enum GraphicsState { ClientLoading, Login,LobbyLoading, Lobby, GameLoading, Game };

		private GraphicsState currentState = GraphicsState.ClientLoading;
        
        public void setState(GraphicsState state)
        {
            switch (currentState)
            {
                case GraphicsState.ClientLoading:
                    quitState_ClientLoading();
                    break;
                case GraphicsState.Login:
                    quitState_Login();
                    break;
                case GraphicsState.LobbyLoading:
                    quitState_LobbyLoading();
                    break;
                case GraphicsState.Lobby:
                    quitState_Lobby();
                    break;
                case GraphicsState.GameLoading:
                    quitState_GameLoading();
                    break;
                case GraphicsState.Game:
                    quitState_Game();
                    break;
            }

            currentState = state;

            switch (currentState)
            {
                case GraphicsState.ClientLoading:
                    enterState_ClientLoading();
                    break;
                case GraphicsState.Login:
                    enterState_Login();
                    break;
                case GraphicsState.LobbyLoading:
                    enterState_LobbyLoading();
                    break;
                case GraphicsState.Lobby:
                    enterState_Lobby();
                    break;
                case GraphicsState.GameLoading:
                    enterState_GameLoading();
                    break;
                case GraphicsState.Game:
                    enterState_Game();
                    break;
            }
        }
        
        #region Enter State

        private void enterState_ClientLoading()
        { }
        private void enterState_Login()
        { }
        private void enterState_LobbyLoading()
        {
			if (currentState != GraphicsState.Lobby)
                Application.LoadLevel("Lobby");      
            
        }
        private void enterState_Lobby()
        {
            
        }
        private void enterState_GameLoading()
        {
            if (currentState != GraphicsState.Game)
                Application.LoadLevel("GameLoader");            
        }
        private void enterState_Game()
        {
            foreach (Player player in Game.players)
            {
                Board board = player.board;
                IBoardGUI gui = (IBoardGUI)Activator.CreateInstance(Type.GetType("Assets.Scripts.GUI.Boards." + board.GetType().Name + "GUI, Assembly-CSharp"));
                gui.createBoard(board);
            }

            uiControllerGame = UIControllerGame.getInstance();
			uiControllerGame.createMinionAndTowerButtons();

            MouseHandler.initialize(this);
            
            // Game sinifindan bilgileri alarak oyun icin gerekli yuklemeleri ve atamalari yap.
            Announcement.make("Welcome to the Summoner's rift!", Announcement.ScreenPosition.MiddleTop, 2.0f);

            updateCashAndIncome();

            loadGameFlag = true;

            StartCoroutine(sendLoadReadyMessage());
        }

        public IEnumerator sendLoadReadyMessage()
        {
            //bekir akmissin ^^
            yield return new WaitForEndOfFrame();
            Assets.Scripts.Engine.Messages.OutgoingMessages.Game.GLoadingStateResult.sendMessage();
        }
        #endregion

        #region Quit State

        private void quitState_ClientLoading()
        { }
        private void quitState_Login()
        { }
        private void quitState_LobbyLoading()
        { }
        private void quitState_Lobby()
        { }
        private void quitState_GameLoading()
        { }
        private void quitState_Game()
        {
			boardGUIs = new LinkedList<IBoardGUI>();
			minionGUIs = new LinkedList<IMinionGUI>();
			towerGUIs = new LinkedList<ITowerGUI>();
			missileGUIs = new LinkedList<IMissileGUI>();
			skillGUIs = new LinkedList<ISkillGUI>();
			areaEffectGUIs = new LinkedList<IAreaEffectGUI>();
		}

        #endregion

        void OnLevelWasLoaded(int level)
        {
            if (Application.loadedLevelName == "Login")
                setState(GraphicsState.Login);
            else if (Application.loadedLevelName == "Lobby")
                setState(GraphicsState.Lobby);
            else if (Application.loadedLevelName == "Game")
                setState(GraphicsState.Game);            
        }

        #endregion
        
        void Start()
        {
            
        }

        void Update()
        {
            if (currentState == GraphicsState.Login)
            {
				Update_Login();
            }
            else if (currentState == GraphicsState.Lobby)
            {
				Update_Lobby();    
			}
            else if (currentState == GraphicsState.Game)
            {
				Update_Game();
            }
        }

        #region OnGUI
        
        void OnGUI()
        {
			if (currentState == GraphicsState.ClientLoading)
			{	
				//nothing to do
			}
            if (currentState == GraphicsState.Login)
            {
				OnGUI_Login();
            }
            else if (currentState == GraphicsState.Lobby)
            {
				OnGUI_Lobby();
            }
            else if (currentState == GraphicsState.Game)
            {   
				OnGUI_Game();
            }
        }

        #endregion

        #region Server Connection

        public void tryingToConnect()
        {
            UIControllerClientStarter.getInstance().tryingToConnect();
        }

        public void connectionFailed()
        {
            UIControllerClientStarter.getInstance().connectionFailed();
        }

        public void connectionSuccessful()
        {
            UIControllerClientStarter.getInstance().connectionSuccessful();

            setState(GraphicsState.Login);			// LobbyLoading'i Login'e cevirdim cunku server zaten simdilik 
													// otomatik olarak EnterLobby mesaji gonderiyor ve lobbyloading 
													// cagiriliyor.		-Batu
			//setState(GraphicsState.LobbyLoading);
        }

        #endregion


    }
}
