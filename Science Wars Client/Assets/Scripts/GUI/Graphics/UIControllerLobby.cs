using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Engine.Messages.OutgoingMessages.Lobby;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.GUI.GUIUtilities;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.GUI.SceneSpecific.Game;
using Assets.Scripts.Engine.ScienceTrees;
using Assets.Scripts.Engine.ScienceTrees.ScienceNodes;

public class UIControllerLobby : MonoBehaviour {

	//Singleton Pattern
	private static UIControllerLobby _instance = null;
	public static UIControllerLobby getInstance()
	{
		if (_instance == null) 
		{
			GameObject go = GameObject.Find("ControllerLobby");
			if (go != null)
				_instance = go.GetComponent<UIControllerLobby>();
		}	
		
		return _instance;
	}

	public UIButton buttonHome;
	public UIButton buttonSettings;
	public UIButton buttonQueue;
	public UIButton buttonScienceTree;
	public UIButton buttonSkills;

	public UIButton buttonPhysTree;
	public UIButton buttonChemTree;
	public UIButton buttonBioTree;

	public GameObject physTreeWindow;
	public GameObject chemTreeWindow;
	public GameObject bioTreeWindow;
	
	public GameObject homeWindow;
	public GameObject queueWindow;
	public GameObject scienceTreeWindow;

	// Home Window
	public UIInput chatInput;
	public UITextList chatMessageList;

	// Queue Window
	public GameObject queueWindowSelectQueuePanel;
	public GameObject queueWindowSearchingForGamePanel;
	public GameObject queueWindowGameFoundPanel;

	// Game Found Window
	public UILabel gameFoundInfoText;
	public UILabel gameFoundCountDown;
	public GameObject gameFoundButtonContainer;
	public GameObject gameFoundSpriteAcceptedPlayer;
	private float countDown = 0;
	private bool isGameFound = false;
	private int numberOfAcceptedPlayers = 0;



	void Start()
	{
		mainMenuTabs = new TabController();
		mainMenuTabs.addTab(buttonHome, homeWindow);
		mainMenuTabs.addTab(buttonQueue, queueWindow);
		mainMenuTabs.addTab(buttonScienceTree, scienceTreeWindow);
		mainMenuTabs.selectTab(buttonHome);

		scienceTreeTabs = new TabController();
		scienceTreeTabs.addTab(buttonPhysTree, physTreeWindow);
		scienceTreeTabs.addTab(buttonChemTree, chemTreeWindow);
		scienceTreeTabs.addTab(buttonBioTree, bioTreeWindow);
		scienceTreeTabs.selectTab(buttonPhysTree);

		TypeIdGenerator.getTowerType(0);
	}

	void Update()
	{
		if (isGameFound) {
			countDown -= Time.deltaTime;

			if (countDown >= 0) {
				int minutes = Mathf.FloorToInt (countDown / 60F);
				int seconds = Mathf.FloorToInt (countDown - minutes * 60);			
				gameFoundCountDown.text = string.Format ("{0:0}:{1:00}", minutes, seconds);
			}
		}

	    if (Input.GetKeyDown(KeyCode.Escape))
	    {
            Assets.Scripts.Engine.Network.server.Disconnect();
	        Application.Quit();
	    }
	}


	//************ TAB CONTROL BEGIN ************//

	private TabController mainMenuTabs;
	private TabController scienceTreeTabs;

	public void closeQueueWindow()
	{
		buttonHome.isEnabled = true;
		buttonSettings.isEnabled = true;
		buttonScienceTree.isEnabled = true;
		buttonSkills.isEnabled = true;
		openHomeWindow();
	}

	public void openQueueWindow()
	{
		if (mainMenuTabs.selectTab(buttonQueue)) {
			queueWindowSelectQueuePanel.SetActive (true);
			queueWindowSearchingForGamePanel.SetActive (false);
			queueWindowGameFoundPanel.SetActive (false);

			buttonHome.isEnabled = false;
			buttonSettings.isEnabled = false;
			buttonScienceTree.isEnabled = false;
			buttonSkills.isEnabled = false;
		}
	}

	public void openHomeWindow()
	{
		mainMenuTabs.selectTab(buttonHome);
	}

	public void openScienceTreeWindow()
	{
		mainMenuTabs.selectTab(buttonScienceTree);
	}

	public void openPhysicsTreeWindow()
	{
		scienceTreeTabs.selectTab(buttonPhysTree);
	}

	public void openChemistryTreeWindow()
	{
		scienceTreeTabs.selectTab(buttonChemTree);
	}

	public void openBiologyTreeWindow()
	{
		scienceTreeTabs.selectTab(buttonBioTree);
	}

	//************ TAB CONTROL END ************//

	public void sendChatMessage()
	{
		//I am not sure what it actually does
		string text = NGUITools.StripSymbols(chatInput.text);
		
		if (!string.IsNullOrEmpty(text))
		{
			chatInput.text = "";
			chatInput.selected = false;
			LChatMessage.sendMessage(text);
		}
	}

	public void showChatMessage(string text)
	{
		if (chatMessageList != null)
			chatMessageList.Add(text);
	}



	public void selectBiology()
	{
		LEnterQueueRequest.sendMessage(ScienceType.BIO.ToString());
		queueWindowSelectQueuePanel.SetActive (false);
	}

	public void selectPhysics()
	{
		LEnterQueueRequest.sendMessage(ScienceType.PHYS.ToString());
		queueWindowSelectQueuePanel.SetActive (false);
	}

	public void selectChemistry()
	{
		LEnterQueueRequest.sendMessage(ScienceType.CHEM.ToString());
		queueWindowSelectQueuePanel.SetActive (false);
	}

	public void showGameSearchingPanel()
	{
		NGUITools.SetActiveSelf(queueWindowGameFoundPanel, false);
		NGUITools.SetActiveSelf(queueWindowSearchingForGamePanel, true);
	}

	public void showGameFoundPanel(float seconds)
	{
		NGUITools.SetActiveSelf(queueWindowSearchingForGamePanel, false);
		// do some initialization
		gameFoundInfoText.text = "The Game is found for you. Are you ready?";
		isGameFound = true;
		countDown = seconds;
		numberOfAcceptedPlayers = 0;
        gameFoundSpriteAcceptedPlayer.transform.localScale = new Vector3(0, 0, 0);
		queueWindowGameFoundPanel.SetActive (true);
		gameFoundButtonContainer.SetActive (true);
	}

	public void gameFoundAnswerYes()
	{
		GReadyStateResult.sendMessage(true);
		gameFoundInfoText.text = "Waiting For Others...";
		gameFoundButtonContainer.SetActive (false);
	}

	public void gameFoundAnswerNo()
	{
		GReadyStateResult.sendMessage(false);
		// TODO tekrar queue'ya sok ya da ceza ver
	}

	public void gameFoundPlayerAnswers(bool result)
	{
		if (result) {
			gameFoundSpriteAcceptedPlayer.transform.localScale += new Vector3(32, 0, 0);
		} else {
			//TODO tekrar queue arama ekranina dondur
		}
	}

	public void cancelQueueWindow()
	{
		LCancelQueueRequest.sendMessage ();
	}
}

public class TabController 
{
	List<UIButton> tabButtons = new List<UIButton>();
	List<GameObject> tabPanels = new List<GameObject>();

	UIButton activeTabButton;
	GameObject activeTabPanel;

	public void addTab(UIButton button, GameObject panel) 
	{
		tabButtons.Add(button);
		tabPanels.Add (panel);
	}

	public bool selectTab(UIButton button) 
	{
		if (activeTabButton == button) return false;

		if (activeTabButton != null)
			activeTabButton.Down = false;

		if (activeTabPanel != null)
			activeTabPanel.SetActive(false);

		activeTabButton = button;
		activeTabPanel = tabPanels[tabButtons.IndexOf(button)];

		activeTabButton.Down = true;
		activeTabPanel.SetActive(true);

		return true;
	}
}
