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
	public partial class Graphics
	{
		void Update_Lobby() 
		{
			if (Input.GetKeyUp(KeyCode.Return))
			{
				if (!UIControllerLobby.getInstance().chatInput.selected)
				{
					UIControllerLobby.getInstance().chatInput.selected = true;
				}
			}
		}

		void OnGUI_Lobby()
		{

		}

		#region Interface Functions

		public void loadLobby()
		{
			setState(GraphicsState.LobbyLoading);
		}
		
		public void displayChatMessage(string senderUsername, string message)
		{
			//textChatOutput += senderUsername + ": " + message + "\n";
			UIControllerLobby.getInstance().showChatMessage(senderUsername + ": " + message);
		}
		
		public void displayQueueResult(bool result)
		{
			if (result)
				UIControllerLobby.getInstance ().showGameSearchingPanel ();
			else
				UIControllerLobby.getInstance().closeQueueWindow();
		}
		
		public void displayGReadyStateRequest(float seconds)
		{
			UIControllerLobby.getInstance().showGameFoundPanel(seconds);
		}
		
		public void displayReadyStates(bool result)
		{
			UIControllerLobby.getInstance ().gameFoundPlayerAnswers (result);
		}

		public void displayCancelQueueResult(bool result) 
		{
			if(result)
				UIControllerLobby.getInstance ().closeQueueWindow ();
		}

		#endregion
	}
}