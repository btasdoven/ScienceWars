using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.GUI.GUIUtilities;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.Engine.Messages.OutgoingMessages.Game;
using System.Collections.Generic;
using Assets.Scripts.Engine.Helpers;
using Assets.Scripts.Engine.Boards;
using Assets.Scripts.GUI.SceneSpecific.Game;
using Assets.Scripts.Engine.Minions;

public class UIControllerGame : MonoBehaviour {

	private static UIControllerGame _instance = null;
	public static UIControllerGame getInstance()
	{
		if (_instance == null) 
		{
			GameObject go = GameObject.Find("ControllerGame");
			if (go != null)
				_instance = go.GetComponent<UIControllerGame>();
		}	
		
		return _instance;
	}

	public UILabel label_paymentTime;
	public UILabel label_randMinionTime;
	public UILabel label_gameTime;

	public UILabel label_cash;
	public UILabel label_income;

	public GameObject panel_MinionInfo;
	public UILabel label_MinionDescription;
	public UILabel label_MinionCost;
	public UILabel label_MinionIncome;
	public UILabel label_MinionReward;
	public UILabel label_MinionHealth;
	public UILabel label_MinionPhysRes;
	public UILabel label_MinionPoisonRes;
	public UILabel label_MinionFireRes;
	public UILabel label_MinionMS;
	public UITexture sprite_MinionIcon;
	public UILabel label_MinionTitle;
	public GameObject button_UpgradeMinionSample;
	public GameObject panel_UpgradeMinionContainer;

	public UILabel label_TowerDescription;
	public GameObject panel_TowerInfo;
	public UILabel label_TowerCost;
	public UILabel label_TowerAttackCD;
	public UILabel label_TowerRange;
	public UITexture sprite_TowerIcon;
	public UILabel label_TowerTitle;
	public GameObject button_UpgradeTowerSample;
	public GameObject panel_UpgradeTowerContainer;

	public GameObject panel_Menu;

    public GameObject selectedTowerOverlayObject;
	public GameObject button_CreateMinion;
	public GameObject button_CreateTower;
	public GameObject createMinionTowerContainer;

	public GameObject panel_Scoreboard;
    public GameObject panel_Scoreboard_Info_Row;
    public List<UILabel> labelList_Scoreboard_hp = new List<UILabel>();
    public List<UILabel> labelList_Scoreboard_name = new List<UILabel>();
    public List<UILabel> labelList_Scoreboard_killedMinion = new List<UILabel>();

    public GameObject panel_AnnouncementsMiddleTop;
    public GameObject panel_AnnouncementsMiddleCenter;
    public GameObject panel_AnnouncementsMiddleBottom;
    public UILabel announcementSampleObject;

    public GameObject panel_EndGameStats;
    public GameObject panel_EndGameStats_Info_Row;

	public UIInput chatInput;
	public UITextList chatMessageList;

	public bool alwaysActiveInfoPanel = false;

	public GameObject chatScreen;
	public float chatScreenShowTime = 4.0f;
	private static float CHATSHOWTIME = 4.0f;

    public Dictionary<Type, GameObject> towerAndMinionButtons = new Dictionary<Type, GameObject>();
    public GameObject createTowerEffect;

    // Use this for initialization
	void Start () 
    {
        initializeScoreboardPanel();
	}
	
	// Update is called once per frame
	void Update () 
    {
		if (Input.GetKeyDown(KeyCode.Tab))
			showScoreboard();
		else if (Input.GetKeyUp(KeyCode.Tab))
			hideScoreboard();
		
		if (Input.GetKeyUp(KeyCode.Escape))
			openMenu();

		#region ChatFunctions
		if (Input.GetKeyUp (KeyCode.Return) && !chatScreen.activeSelf)
		{
			chatScreen.SetActive(true);
			chatInput.selected = true;
		}
		else if (Input.GetKeyUp (KeyCode.Return) && chatScreen.activeSelf) 
		{
			chatScreenShowTime = CHATSHOWTIME;

			if(chatInput.text == "")
				chatScreenShowTime = 0.0f;
		}

		if(chatScreen.activeSelf)
			chatScreenShowTime = chatScreenShowTime - Chronos.deltaTime;

		if(chatScreenShowTime <= 0.0f && chatInput.text == "")
		{
			chatScreen.SetActive(false);
			chatScreenShowTime = CHATSHOWTIME;
		}
		#endregion
	}

    public void initializeEndGameStatsPanel()
    {
        Transform bg_endgamestats = panel_EndGameStats.transform.Find("Background").transform;
        bg_endgamestats.localScale = new Vector3(bg_endgamestats.localScale.x, 27 * (Game.players.Count + 3) + 70, bg_endgamestats.localScale.z);
        panel_EndGameStats.transform.Find("Glow").transform.localScale = bg_endgamestats.localScale + new Vector3(42, 42, 0);
        panel_EndGameStats.transform.Find("Title").transform.localPosition = new Vector3(0, bg_endgamestats.localScale.y / 2 + 10, 0);
        panel_EndGameStats.transform.Find("Information").transform.localPosition = new Vector3(0, bg_endgamestats.localScale.y / 2 - 20, 0);
        panel_EndGameStats.transform.Find("Headers").transform.localPosition = new Vector3(0, bg_endgamestats.localScale.y / 2 - 90, 0);
        panel_EndGameStats.transform.Find("button_Exit").transform.localPosition = new Vector3(52.5f, -bg_endgamestats.localScale.y / 2 + 25, -10);
        panel_EndGameStats.transform.Find("button_Continue").transform.localPosition = new Vector3(-52.5f, -bg_endgamestats.localScale.y / 2 + 25, -10);

        Transform parent_container = panel_EndGameStats.transform.Find("endGameStatsContainer").transform;
        
        var children = new List<GameObject>();
        foreach (Transform child in parent_container) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));

		UILabel info = panel_EndGameStats.transform.Find ("Information").GetComponentsInChildren<UILabel>(true)[0];

		if (PlayerMe.self.healthPoints <= 0)
			info.text = "[AA1111]Defeat[-]\n";
		else
			info.text = "[11FF11]Victory[-]\n";

		info.text += "You have earned [11FF11]120 ";

		switch(PlayerMe.self.board.scienceType) 
		{
			case ScienceType.BIO:
				info.text += "Biology";
				break;
			case ScienceType.CHEM:
				info.text += "Chemistry";
				break;
			case ScienceType.PHYS:
				info.text += "Physics";
				break;
		}

		info.text += " Points.[-]";

        int index = 0;
        foreach (Player player in Game.players)
        {
            //end game stats
            GameObject row = (GameObject)GameObject.Instantiate(panel_EndGameStats_Info_Row);
            row.transform.parent = parent_container;
            row.transform.localScale = new Vector3(1, 1, 1);
            row.transform.localPosition = new Vector3(0, bg_endgamestats.localScale.y / 2 - 90 - 27 * (index + 1), 0);
            row.SetActive(true);

            UILabel[] arr = row.GetComponentsInChildren<UILabel>(true);

            arr[0].text = player.user.username;
            arr[1].text = player.healthPoints.ToString();
			arr[2].text = Game.statTracker.getCashOfPlayer(player).ToString();
			arr[3].text = Game.statTracker.getIncomeOfPlayer(player).ToString();
            arr[4].text = Game.statTracker.getMoneyEarnedByPlayer(player).ToString();
            arr[5].text = Game.statTracker.getMoneySpendByPlayer(player).ToString();
            arr[6].text = Game.statTracker.getMissilesFiredByPlayer(player).ToString();
            arr[7].text = Game.statTracker.getTowersBuiltByPlayer(player).ToString();
            arr[8].text = Game.statTracker.getMinionsKilledByPlayer(player).ToString();
            arr[9].text = Game.statTracker.getMinionsSendByPlayer(player).ToString();
            arr[10].text = Game.statTracker.getMinionsPassedOfPlayer(player).ToString();

            index++;
        }
        panel_EndGameStats.SetActive(true);
    }

    private void initializeScoreboardPanel() 
    {
        Transform bg_scoreboard = panel_Scoreboard.transform.Find("Background").transform;
        bg_scoreboard.localScale = new Vector3(bg_scoreboard.localScale.x, 21 * (Game.players.Count + 3), bg_scoreboard.localScale.z);
        panel_Scoreboard.transform.Find("Glow").transform.localScale = bg_scoreboard.localScale + new Vector3(42, 42, 0);
        panel_Scoreboard.transform.Find("Title").transform.localPosition = new Vector3(0, bg_scoreboard.localScale.y / 2 + 10, 0);
        panel_Scoreboard.transform.Find("Headers").transform.localPosition = new Vector3(0, bg_scoreboard.localScale.y / 2 - 30, 0);

        int index = 0;
        foreach (Player player in Game.players)
        {
            //scoreboard
            GameObject row = (GameObject)GameObject.Instantiate(panel_Scoreboard_Info_Row);
            row.transform.parent = panel_Scoreboard.transform;
            row.transform.localScale = new Vector3(1, 1, 1);
            row.transform.localPosition = new Vector3(0, bg_scoreboard.localScale.y / 2 - 30 - 21 * (index + 1), 0);
            row.SetActive(true);

            UILabel[] arr = row.GetComponentsInChildren<UILabel>(true);
            arr[2].text = player.user.username;
            arr[1].text = "0";
            arr[0].text = player.healthPoints.ToString();

            labelList_Scoreboard_name.Add(arr[2]);
            labelList_Scoreboard_killedMinion.Add(arr[1]);
            labelList_Scoreboard_hp.Add(arr[0]);

            index++;
        }
    }

	public void openMenu()
	{
		NGUITools.SetActive(panel_Menu, true);
	}

	public void closeMenu()
	{
		NGUITools.SetActive(panel_Menu, false);
	}

	public void button_ExitClick()
	{
		Assets.Scripts.Engine.Messages.OutgoingMessages.Game.GQuitGameRequest.sendMessage();
		closeMenu();
	}

	public void setTimes(float paymentTime, float randMinionTime, float gameTime)
	{
		//TODO her seferinde degismesini optimize et. sadece saniyede bir ekrana yazsin degisikligi.
		paymentTime = Math.Max(paymentTime, 0);
		int minutesPayment = Mathf.FloorToInt(paymentTime / 60F);
		int secondsPayment = Mathf.FloorToInt(paymentTime - minutesPayment * 60);
		string niceTimePayment = string.Format("{0:0}:{1:00}", minutesPayment, secondsPayment);

		randMinionTime = Math.Max(randMinionTime, 0);
		int minutesRandomMinion = Mathf.FloorToInt(randMinionTime / 60F);
		int secondsRandomMinion = Mathf.FloorToInt(randMinionTime - minutesRandomMinion * 60);
		string niceTimeRandomMinion = string.Format("{0:0}:{1:00}", minutesRandomMinion, secondsRandomMinion);

		gameTime = Math.Max(gameTime, 0);
		int minutesGameTime = Mathf.FloorToInt(gameTime / 60F);
		int secondsGameTime = Mathf.FloorToInt(gameTime - minutesGameTime * 60);
		string niceGameTime = string.Format("{0:0}:{1:00}", minutesGameTime, secondsGameTime);

        label_paymentTime.text = niceTimePayment; // "Payment\n" + niceTimePayment;
        label_randMinionTime.text = niceTimeRandomMinion; // "Random Minion\n" + niceTimeRandomMinion;
		label_gameTime.text = niceGameTime;
	}

	public void setMoney(float cash, float income)
	{
        label_cash.text = cash.ToString(); // "cash: " + cash.ToString();
        label_income.text = income.ToString(); // "income: " + income.ToString();
	}

	public void createMinionAndTowerButtons()
	{
        var children = new System.Collections.Generic.List<GameObject>();
		foreach (Transform child in createMinionTowerContainer.transform) 
            children.Add(child.gameObject);
        children.ForEach(child => GameObject.Destroy(child));

		int btnIndex = 0;
		button_CreateTower.SetActive(true);
		button_CreateMinion.SetActive(true);

        // sort minions order by cost
        List<Type> minionsSortedByCost = new List<Type>();
        for (int j = 0; j < PlayerMe.availableMinionTypes.Count; j++)
            if (TypeIdGeneratorGUI.minionGuiInst.ContainsKey(TypeIdGenerator.getMinionId(PlayerMe.availableMinionTypes[j])))
                minionsSortedByCost.Add(PlayerMe.availableMinionTypes[j]);
        minionsSortedByCost.Sort( delegate(Type t1, Type t2) {
            Minion m1 = TypeIdGenerator.getMinionClass(TypeIdGenerator.getMinionId(t1));
            Minion m2 = TypeIdGenerator.getMinionClass(TypeIdGenerator.getMinionId(t2));
            if (m1.getCost() < m2.getCost()) return -1;
            else return 1; 
        });

		foreach(Type minionType in minionsSortedByCost)
		{
            int minionTypeId = TypeIdGenerator.getMinionId(minionType);
			if(TypeIdGeneratorGUI.minionGuiInst.ContainsKey(minionTypeId))
			{
				GameObject button = (GameObject)GameObject.Instantiate(button_CreateMinion);
				button.transform.parent = createMinionTowerContainer.transform;
				button.transform.localScale = new Vector3(1, 1, 1);
				button.transform.localPosition = button_CreateMinion.transform.localPosition + new Vector3(50 * btnIndex, 0, 0);

				UIButtonMessage[] button_messages = button.GetComponents<UIButtonMessage>();
				foreach (var btn_msg in button_messages)
					btn_msg.parameter = minionTypeId.ToString();

				IMinionGUI minionGUI = TypeIdGeneratorGUI.minionGuiInst[minionTypeId];
				minionGUI.drawCreateMinionButtonGUI(button);
                towerAndMinionButtons.Add(minionType, button);
				btnIndex++;
			}
		}

        // sort towers order by cost
        List<Type> towersSortedByCost = new List<Type>();
        for (int j = 0; j < PlayerMe.availableTowerTypes.Count; j++)
            if (TypeIdGeneratorGUI.towerGuiInst.ContainsKey(TypeIdGenerator.getTowerId(PlayerMe.availableTowerTypes[j])))
                towersSortedByCost.Add(PlayerMe.availableTowerTypes[j]);
        towersSortedByCost.Sort(delegate(Type t1, Type t2)
        {
            Tower m1 = TypeIdGenerator.getTowerClass(TypeIdGenerator.getTowerId(t1));
            Tower m2 = TypeIdGenerator.getTowerClass(TypeIdGenerator.getTowerId(t2));
            if (m1.getCost() < m2.getCost()) return -1;
            else return 1;
        });

		btnIndex = 0;
		foreach(Type towerType in towersSortedByCost)
		{
            int towerTypeId = TypeIdGenerator.getTowerId(towerType);
			if(TypeIdGeneratorGUI.towerGuiInst.ContainsKey(towerTypeId))
			{
				GameObject button = (GameObject)GameObject.Instantiate(button_CreateTower);
				button.transform.parent = createMinionTowerContainer.transform;
				button.transform.localScale = new Vector3(1, 1, 1);
				button.transform.localPosition = button_CreateTower.transform.localPosition + new Vector3(50 * btnIndex, 0, 0);

				UIButtonMessage[] button_messages = button.GetComponents<UIButtonMessage>();
				foreach (var btn_msg in button_messages)
					btn_msg.parameter = towerTypeId.ToString();
				
				ITowerGUI towerGUI = TypeIdGeneratorGUI.towerGuiInst[towerTypeId];
				towerGUI.drawCreateTowerButtonGUI(button);
                towerAndMinionButtons.Add(towerType, button);
				btnIndex++;
			}
		}

		button_CreateTower.SetActive(false);
		button_CreateMinion.SetActive(false);
	}

	public void createMinion(string minionTypeId)
	{
        int minionId = Int32.Parse(minionTypeId);
        if (UICamera.currentTouchID == -2)
        {
            panel_TowerInfo.SetActive(false);
            alwaysActiveInfoPanel = true;
            IMinionGUI minionGUI = TypeIdGeneratorGUI.minionGuiInst[minionId];
            minionGUI.drawInfoPanelGUI();
        }
        else
        {
            if (PlayerMe.cash < TypeIdGenerator.getMinionClass(minionId).getCost())
                Announcement.make("[FF0000]Not enough money[-]", Announcement.ScreenPosition.MiddleBottom, 2.0f, 20.0f);
            else
                Assets.Scripts.Engine.Messages.OutgoingMessages.Game.GCreateMinionRequest.sendMessage(minionId);
        }
	}

	public void createTower(string towerTypeId)
	{
		MouseHandler.selectedTowerType = TypeIdGenerator.getTowerType(Int32.Parse(towerTypeId));
        if (PlayerMe.cash < TypeIdGenerator.getTowerClass(Int32.Parse(towerTypeId)).getCost())
            Announcement.make("[FF0000]Not enough money[-]", Announcement.ScreenPosition.MiddleBottom, 2.0f, 20.0f);
        else
        {
            selectedTowerOverlayObject.transform.position = towerAndMinionButtons[MouseHandler.selectedTowerType].transform.position;
            if (!selectedTowerOverlayObject.activeInHierarchy)
                selectedTowerOverlayObject.SetActive(true);
        }
	}

    public void closeInfoPanel()
    {
        panel_MinionInfo.SetActive(false);
        panel_TowerInfo.SetActive(false);
        alwaysActiveInfoPanel = false;
    }

	public void upgradeMinion(string minionTypeIds)
	{
		var arr = minionTypeIds.Split(' ');
		GUpgradeMinionRequest.sendMessage(Int32.Parse(arr[0]), Int32.Parse(arr[1]));
	}

	public void upgradeTower(string towerTypeIds)
	{
        var types = towerTypeIds.Split(' ');
        GUpgradeTowerRequest.sendMessage(MouseHandler.lastSelectedTower.getTower(), Int32.Parse(types[1]) );
	}

	public void activateTowerInfoPanel(string towerTypeId)
	{
        if (!alwaysActiveInfoPanel)
        {
            alwaysActiveInfoPanel = false;
            panel_MinionInfo.SetActive(false);
            ITowerGUI towerGUI = TypeIdGeneratorGUI.towerGuiInst[Int32.Parse(towerTypeId)];
            towerGUI.drawInfoPanelGUI();
        }
	}

	public void activateMinionInfoPanel(string minionTypeId)
	{
        if (!alwaysActiveInfoPanel)
        {
            alwaysActiveInfoPanel = false;
            panel_TowerInfo.SetActive(false);
            IMinionGUI minionGUI = TypeIdGeneratorGUI.minionGuiInst[Int32.Parse(minionTypeId)];
            minionGUI.drawInfoPanelGUI();
        }
	}

	public void deactivateTowerInfoPanel(string towerTypeId)
	{
        if (!alwaysActiveInfoPanel)        
		    panel_TowerInfo.SetActive(false);
	}

	public void deactivateMinionInfoPanel(string minionTypeId)
	{
		if (!alwaysActiveInfoPanel)
			panel_MinionInfo.SetActive(false);
	}

	public void showScoreboard()
	{
        int index = 0;
        foreach (Player p in Game.players)
        {
            labelList_Scoreboard_killedMinion[index].text = "-";
            labelList_Scoreboard_hp[index].text = p.healthPoints.ToString();
            index++;
        }

		panel_Scoreboard.SetActive(true);
	}

	public void hideScoreboard()
	{
		panel_Scoreboard.SetActive(false);
	}

	public void sendChatMessage()
	{
		//I am not sure what it actually does
		string text = NGUITools.StripSymbols(chatInput.text);
		
		if (!string.IsNullOrEmpty(text))
		{
			chatInput.text = "";
			chatInput.selected = false;
			GChatMessage.sendMessage(text);
		}
	}
	
	public void showChatMessage(string text)
	{
		chatScreenShowTime = CHATSHOWTIME;
		chatScreen.SetActive (true);

		if (chatMessageList != null)
			chatMessageList.Add(text);
	}

    public void button_EndGameStats_ContinueClick()
    {
        panel_EndGameStats.SetActive(false);
    }
}
