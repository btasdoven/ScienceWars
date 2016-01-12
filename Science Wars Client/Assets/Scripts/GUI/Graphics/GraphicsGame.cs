using Assets.Scripts.Engine;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.IGUI;
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
using Assets.Scripts.Engine.Minions.Physics;
using Assets.Scripts.Engine.Minions.Biology;
using Assets.Scripts.GUI.Minions;
using Assets.Scripts.Engine.Towers.Physics;
using Assets.Scripts.GUI.Towers;
using Assets.Scripts.Engine.Towers.Biology;
using Assets.Scripts.Engine.Effects.TowerEffects;
using Assets.Scripts.Engine.Messages.OutgoingMessages.Game;

namespace Assets.Scripts.GUI.Graphics
{
	public partial class Graphics
	{
		private int w = Screen.width;
		private int h = Screen.height;
		
		public bool loadGameFlag = false;
		public bool drawUserFlag = false;
		public bool drawMenuFlag = false;
		
		private bool quitStateAnimationWaitFlag = false;
		private int countDownFlag = -1;
		
		public UnityEngine.GUIStyle style;
        private UIControllerGame uiControllerGame;
        
		private LinkedList<IBoardGUI> boardGUIs = new LinkedList<IBoardGUI>();
		private LinkedList<IMinionGUI> minionGUIs = new LinkedList<IMinionGUI>();
		private LinkedList<ITowerGUI> towerGUIs = new LinkedList<ITowerGUI>();
		private LinkedList<IMissileGUI> missileGUIs = new LinkedList<IMissileGUI>();
		private LinkedList<ISkillGUI> skillGUIs = new LinkedList<ISkillGUI>();
		private LinkedList<IAreaEffectGUI> areaEffectGUIs = new LinkedList<IAreaEffectGUI>();
        private LinkedList<IMinionEffectGUI> minionEffectGUIs = new LinkedList<IMinionEffectGUI>();
        private LinkedList<ITowerEffectGUI> towerEffectGUIs = new LinkedList<ITowerEffectGUI>(); 

		#region Update

		void Update_Game()
		{			
			stepBoards();
			stepTowers();
			stepMinions();
			stepMissiles();
			stepAreaEffects();
			stepMinionEffects();
			stepSkills();

            MouseHandler.handleMouseClicks();
		}

		void stepBoards()
		{
			LinkedListNode<IBoardGUI> boardNode = boardGUIs.First;
			LinkedListNode<IBoardGUI> tmpNode;
			
			while (boardNode != null)
			{
				if (boardNode.Value.isDestroyable())
				{
					tmpNode = boardNode;
					boardNode = boardNode.Next;
					boardGUIs.Remove(tmpNode);
				}
				else
				{
					boardNode.Value.step();
					boardNode = boardNode.Next;
				}
			}
		}
		
		void stepTowers()
		{
			LinkedListNode<ITowerGUI> towerNode = towerGUIs.First;
			LinkedListNode<ITowerGUI> tmpNode;
			
			while (towerNode != null)
			{
				if (towerNode.Value.isDestroyable())
				{
					tmpNode = towerNode;
					towerNode = towerNode.Next;
					towerGUIs.Remove(tmpNode);
				}
				else
				{
					towerNode.Value.step();
					towerNode = towerNode.Next;
				}
			}
		}
		
		void stepMinions()
		{
			LinkedListNode<IMinionGUI> minionNode = minionGUIs.First;
			LinkedListNode<IMinionGUI> tmpNode;
			
			while (minionNode != null)
			{
				if (minionNode.Value.isDestroyable())
				{
					tmpNode = minionNode;
					minionNode = minionNode.Next;
					minionGUIs.Remove(tmpNode);
				}
				else
				{
					minionNode.Value.step();
					minionNode = minionNode.Next;
				}
			}
		}
		
		void stepMissiles()
		{
			LinkedListNode<IMissileGUI> missileNode = missileGUIs.First;
			LinkedListNode<IMissileGUI> tmpNode;
			
			while (missileNode != null)
			{
				if (missileNode.Value.isDestroyable())
				{
					tmpNode = missileNode;
					missileNode = missileNode.Next;
					missileGUIs.Remove(tmpNode);
				}
				else
				{
					missileNode.Value.step();
					missileNode = missileNode.Next;
				}
			}
		}
		
		void stepAreaEffects()
		{
			LinkedListNode<IAreaEffectGUI> areaEffectNode = areaEffectGUIs.First;
			LinkedListNode<IAreaEffectGUI> tmpNode;
			
			while (areaEffectNode != null)
			{
				if (areaEffectNode.Value.isDestroyable())
				{
					tmpNode = areaEffectNode;
					areaEffectNode = areaEffectNode.Next;
					areaEffectGUIs.Remove(tmpNode);
				}
				else
				{
					areaEffectNode.Value.step();
					areaEffectNode = areaEffectNode.Next;
				}
			}
		}

        void stepMinionEffects()
        {
            LinkedListNode<IMinionEffectGUI> minionEffectNode = minionEffectGUIs.First;
            LinkedListNode<IMinionEffectGUI> tmpNode;

            while (minionEffectNode != null)
            {
                if (minionEffectNode.Value.isDestroyable())
                {
                    tmpNode = minionEffectNode;
                    minionEffectNode = minionEffectNode.Next;
                    minionEffectGUIs.Remove(tmpNode);
                }
                else
                {
                    minionEffectNode.Value.step();
                    minionEffectNode = minionEffectNode.Next;
                }
            }
        }
		
		void stepSkills()
		{
			LinkedListNode<ISkillGUI> towerNode = skillGUIs.First;
			LinkedListNode<ISkillGUI> tmpNode;
			
			while (towerNode != null)
			{
				if (towerNode.Value.isDestroyable())
				{
					tmpNode = towerNode;
					towerNode = towerNode.Next;
					skillGUIs.Remove(tmpNode);
				}
				else
				{
					towerNode.Value.step();
					towerNode = towerNode.Next;
				}
			}
		}

		#endregion

		#region OnGUI

		void OnGUI_Game()
		{
			if (Game.gameState == Game.GameState.STARTCOUNTDOWN)
			{
				if (countDownFlag == -1)
					countDownFlag = (int)Game.pauseTime + 1;
				 
				if ((int)Game.pauseTime < countDownFlag)
				{
					Announcement.make(countDownFlag.ToString(), Announcement.ScreenPosition.MiddleCenter, 1.0f, 50.0f);
					countDownFlag--;
				}
			}
			
			if (quitStateAnimationWaitFlag)
				quitStateAnimationWaitFlag = false;


			if (loadGameFlag)
                uiControllerGame.setTimes(Engine.Game.nextPaymentTime, Engine.Game.nextRandomMinionTime, Engine.Game.gameTime); 
		}

        /*
        // bu fonksiyonu kullanmiyoruz. MouseHandler'i kullaniyoruz.
        private void ingameClickHandler()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && GUIUtility.hotControl == 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                bool towerSlotClicked = false;
                bool towerClicked = false;
                bool minionClicked = false;

                if (Physics.Raycast(ray, out hitInfo, 1000.0f))
                {
                    GameObject obje = hitInfo.collider.gameObject;

                    if (obje.name.StartsWith("towerSlot_"))
                    {
                        towerSlotClicked = true;

                        int towerSlot = System.Int32.Parse(obje.name.Substring("towerSlot_".Length)) - 1;
                        int boardId = System.Int32.Parse(obje.transform.parent.parent.parent.gameObject.name.Substring("board_".Length));
						
                        Board board = Game.getBoardById(boardId);
                        if (board == PlayerMe.self.board)
                        {
                            if (board.towers[towerSlot] == null)
                            {
                                if (selectedTowerType != null)
                                    sendCreateTowerRequest(selectedTowerType, towerSlot);
                                else
                                {
                                    if (lastSelectedTower != null)
                                    {
                                        lastSelectedTower.onTowerUnselected();
                                        UIControllerGame.getInstance().panel_TowerInfo.SetActive(false);
                                    }
                                    lastSelectedTower = null;
                                }
                            }
                            else
                            {
                                if (lastSelectedTower != null)
                                    lastSelectedTower.onTowerUnselected();
								
                                lastSelectedTower = (ITowerGUI)board.towers[towerSlot].tag;
                                activateTowerInfo(lastSelectedTower);
								
                                lastSelectedTower.onTowerSelected();

                                selectedTowerType = null;
                                UIControllerGame.getInstance().selectedTowerOverlayObject.SetActive(false);
                            }
                            //((Assets.Scripts.GUI.Interfaces.IBoardGUI) board.tag).onMouseOverTower(towerSlot);
                        }

                        if (lastSelectedMinion != null)
                        {
                            lastSelectedMinion.onMinionUnselected();
                            UIControllerGame.getInstance().panel_MinionInfo.SetActive(false);
                        }
                        lastSelectedMinion = null;
                    }
                    else if (obje.name.StartsWith("t_"))
                    {
                        minionClicked = true;

                        try
                        {
                            string objName = obje.name;
                            string boardStr = obje.name.Substring(2, objName.LastIndexOf("_") - 2);
                            string indexStr = obje.name.Substring(objName.LastIndexOf("_") + 1);
                            int boardId = System.Int32.Parse(boardStr);
                            int indexOnBoard = System.Int32.Parse(indexStr);
                            Board board = Game.getBoardById(boardId);
                            Tower tower = board.towers[indexOnBoard];

                            // daha once bir kuleye tiklanmissa unselect'ini cagir.
                            if (lastSelectedTower != null)
                                lastSelectedTower.onTowerUnselected();

                            lastSelectedTower = (ITowerGUI)tower.tag;
                            activateTowerInfo(lastSelectedTower);

                            lastSelectedTower.onTowerSelected();

                            selectedTowerType = null;
                            UIControllerGame.getInstance().selectedTowerOverlayObject.SetActive(false);
                        }
                        catch (UnityException e)
                        {
                            Debug.Log("Mouse Handler::objeNameStartsWith:t_ \t -inappropriate name: '" + obje.name +"'");
                        }
                        if (lastSelectedMinion != null)
                        {
                            lastSelectedMinion.onMinionUnselected();
                            UIControllerGame.getInstance().panel_MinionInfo.SetActive(false);
                        }
                        lastSelectedMinion = null;
                    }
                    else if (obje.name.StartsWith("m_"))
                    {
                        minionClicked = true;

                        try
                        {
                            string objName = obje.name;
                            string instanceIDstr = obje.name.Substring(2);
                            int instanceID = System.Int32.Parse(instanceIDstr);
                            Minion minion = Game.getMinionById(instanceID);

                            if(lastSelectedMinion != null)
                                lastSelectedMinion.onMinionUnselected();
                            lastSelectedMinion = (IMinionGUI)minion.tag;
							
                            activateMinionInfo(lastSelectedMinion);

                            lastSelectedMinion.onMinionSelected();

                        }
                        catch (UnityException e)
                        {
                            Debug.Log("Mouse Handler::objeNameStartsWith:m_");
                        }

                        // Unselected tower
                        if (lastSelectedTower != null)
                        {
                            lastSelectedTower.onTowerUnselected();
                            UIControllerGame.getInstance().panel_TowerInfo.SetActive(false);
                        }
                        lastSelectedTower = null;

                        selectedTowerType = null;
                        UIControllerGame.getInstance().selectedTowerOverlayObject.SetActive(false);
                    }
                    else
                    {
                        Ray rayNGUI = GameObject.Find ("NGUICamera").camera.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hitInfoNGUI;
                        // eger ekranda bos bir yere tiklamissam
                        if (!Physics.Raycast(rayNGUI, out hitInfoNGUI, 1000.0f)) { // 9: GUI Layer
                            // Unselected tower
                            if (lastSelectedTower != null)
                            {
                                lastSelectedTower.onTowerUnselected();
                                UIControllerGame.getInstance().panel_TowerInfo.SetActive(false);
                            }
                            lastSelectedTower = null;
                            selectedTowerType = null;
                            UIControllerGame.getInstance().selectedTowerOverlayObject.SetActive(false);

                            if(lastSelectedMinion != null)
                            {
                                lastSelectedMinion.onMinionUnselected();
                                UIControllerGame.getInstance().panel_MinionInfo.SetActive(false);
                            }
                            lastSelectedMinion = null;
                        }
                    }
                }
                else // collider'i olmayan bir seye tiklamissak ya da hicbir seye tiklamamissak
                {
                    if (lastSelectedTower != null)
                    {
                        lastSelectedTower.onTowerUnselected();
                        UIControllerGame.getInstance().panel_TowerInfo.SetActive(false);
                    }
                    lastSelectedTower = null;
                    selectedTowerType = null;
                    UIControllerGame.getInstance().selectedTowerOverlayObject.SetActive(false);

                    if (lastSelectedMinion != null)
                    {
                        lastSelectedMinion.onMinionUnselected();
                        UIControllerGame.getInstance().panel_MinionInfo.SetActive(false);
                    }
                    lastSelectedMinion = null;
                }
            }
        }
        */

        public void activateTowerInfo(ITowerGUI towerGUI)
		{
            uiControllerGame.alwaysActiveInfoPanel = true;
            uiControllerGame.panel_MinionInfo.SetActive(false);
			towerGUI.drawInfoPanelGUI();
		}
		
		public void activateMinionInfo(IMinionGUI minionGUI)
		{
            uiControllerGame.alwaysActiveInfoPanel = true;
            uiControllerGame.panel_TowerInfo.SetActive(false);
			minionGUI.drawInfoPanelGUI();
		}
		
		public void sendCreateTowerRequest(Type type, int slotId)
		{
            int towerId = TypeIdGenerator.getTowerId(type);

            if (PlayerMe.cash < TypeIdGenerator.getMinionClass(towerId).getCost())
                Announcement.make("[FF0000]Not enough money[-]", Announcement.ScreenPosition.MiddleBottom, 2.0f, 20.0f);
            else
            {
                GCreateTowerRequest.sendMessage(towerId, slotId);
                if (!Input.GetKey(KeyCode.LeftControl))
                {
                    MouseHandler.selectedTowerType = null;
                    uiControllerGame.selectedTowerOverlayObject.SetActive(false);
                }
            }
		}
		
		#endregion

		#region Interface Functions

		public void loadGame()
		{
			setState(GraphicsState.GameLoading);
		}

	    public void destroyGame()
	    {
		    boardGUIs = new LinkedList<IBoardGUI>();
		    minionGUIs = new LinkedList<IMinionGUI>();
		    towerGUIs = new LinkedList<ITowerGUI>();
		    missileGUIs = new LinkedList<IMissileGUI>();
		    skillGUIs = new LinkedList<ISkillGUI>();
		    areaEffectGUIs = new LinkedList<IAreaEffectGUI>();
            minionEffectGUIs = new LinkedList<IMinionEffectGUI>();
            towerEffectGUIs = new LinkedList<ITowerEffectGUI>();
	    }

	    public void quitGameState(Engine.Game.GameState gameState)
		{
			// TODO
		}
		
		public void enterGameState(Engine.Game.GameState gameState)
		{
			// TODO
		}
		
		public void displayStartCountDown(float seconds)
		{
			countDownFlag = -1;
		}
		
		public void updateCashAndIncome()
		{
			// muhtemelen burada hicbir is yapmaya gerek yok. adamin para gostergesinin etrafinda isiklar cikartabiliriz paranin degistigine vurgu yapmak icin.
            uiControllerGame.setMoney(PlayerMe.cash, PlayerMe.income);

            foreach (var button in uiControllerGame.towerAndMinionButtons)    // paramizin yetmedigi butonlari kirmizi yapalim
            {
                if (typeof(Minion).IsAssignableFrom(button.Key)) 
                {                    
                    if (TypeIdGenerator.getMinionClass(TypeIdGenerator.getMinionId(button.Key)).getCost() > PlayerMe.cash)
                    {
                        foreach (var obj in button.Value.transform.GetComponentsInChildren<UISlicedSprite>(true))
                            if (obj.gameObject.transform.name == "NotEnoughMoneyLayer")
                                obj.gameObject.SetActive(true);                    
                    }
                    else
                    {
                        foreach (var obj2 in button.Value.transform.GetComponentsInChildren<UISlicedSprite>(true))
                            if (obj2.gameObject.transform.name == "NotEnoughMoneyLayer")
                                obj2.gameObject.SetActive(false);
                    }
                }
                else if (typeof(Tower).IsAssignableFrom(button.Key))
                {
                    if (TypeIdGenerator.getTowerClass(TypeIdGenerator.getTowerId(button.Key)).getCost() > PlayerMe.cash)
                    {
                        foreach (var obj in button.Value.transform.GetComponentsInChildren<UISlicedSprite>(true))
                            if (obj.gameObject.transform.name == "NotEnoughMoneyLayer")
                                obj.gameObject.SetActive(true);
                    }
                    else
                    {
                        foreach (var obj2 in button.Value.transform.GetComponentsInChildren<UISlicedSprite>(true))
                            if (obj2.gameObject.transform.name == "NotEnoughMoneyLayer")
                                obj2.gameObject.SetActive(false);
                    }
                }
            }
		}
		
		public void updateNextRandomMinionTime()
		{
			// randomMinionTime degeri zaten enginde suan update edilmis halde. sen sadece degisiklik oldugunu isikli misikli gosterebilirsin
		}
		
		public void updateNextPaymentTime()
		{
			// paymentTime degeri zaten enginde suan update edilmis halde. sen sadece degisiklik oldugunu isikli misikli gosterebilirsin
		}
		
		public void updatePlayerHealth(Engine.Player player)
		{
            int index = 0;
            foreach (Player p in Game.players) {
                uiControllerGame.labelList_Scoreboard_hp[index].text = p.healthPoints.ToString();
                index++;
            }

			if (player.healthPoints == 0)
			{
				Announcement.make("Player " + player.user.username + " has been defeated!", Announcement.ScreenPosition.MiddleTop, 2.0f);
			}
			// TODO playerHealth degeri zaten enginde suan update edilmis halde. sen sadece degisiklik oldugunu isikli misikli gosterebilirsin
		}
		
		public void createTower(Tower tower)
		{
			ITowerGUI gui = (ITowerGUI)Activator.CreateInstance(Type.GetType("Assets.Scripts.GUI.Towers." + tower.GetType().Name + "GUI, Assembly-CSharp"));
			towerGUIs.AddLast(gui);
			gui.createTower(tower);
		}
		
		public void addTowerEffect(Tower tower, ITowerEffect effect)
		{
			// TODO
		}
		
		public void upgradeTower(Tower tower)
		{
			createTower (tower);
            if (tower.board == PlayerMe.self.board)
            {
                MouseHandler.lastSelectedTower = (ITowerGUI)tower.tag;
                MouseHandler.lastSelectedTower.onTowerSelected();
                ((ITowerGUI)tower.tag).drawInfoPanelGUI();
            }
		}
        
        public void tower_laserTower_target(LaserTower tower, Minion targetMinion)
        {
            LaserTowerGUI gui = tower.tag as LaserTowerGUI;
            gui.targetMinion(targetMinion);
        }

        public void tower_laserTower_untarget(LaserTower tower, int untargetMinionId)
        {
            if (tower is LaserTower)
            {
                LaserTowerGUI gui = tower.tag as LaserTowerGUI;
                gui.untargetMinion(untargetMinionId);
            }
        }

        public void tower_droseraTower_bite(DroseraTower tower, Minion minion)
        {
            DroseraTowerGUI gui = tower.tag as DroseraTowerGUI;
            gui.biteMinion(minion);
        }

        public void tower_blackHoleTower_teleportStart(Minion minion)
        {
            GameObject.Instantiate(BlackHoleTowerGUI.teleportStartEffectObject, minion.getWorldHeadPosition(), Quaternion.identity);
        }

        public void tower_blackHoleTower_teleportEnd(Minion minion)
        {
            GameObject.Instantiate(BlackHoleTowerGUI.teleportEndEffectObject, minion.getWorldHeadPosition(), Quaternion.identity);
        }

        public void upgradeMinion(Type oldMinionType, Type upgradedMinionType)
        {
            GameObject button = uiControllerGame.towerAndMinionButtons[oldMinionType];
            int minionId = TypeIdGenerator.getMinionId(upgradedMinionType);
            IMinionGUI minionGUI = TypeIdGeneratorGUI.minionGuiInst[minionId];
           
            UIButtonMessage[] button_messages = button.GetComponents<UIButtonMessage>();
            foreach (var btn_msg in button_messages)
                btn_msg.parameter = minionId.ToString();

            minionGUI.drawCreateMinionButtonGUI(button);
            uiControllerGame.towerAndMinionButtons.Remove(oldMinionType);
            uiControllerGame.towerAndMinionButtons.Add(upgradedMinionType, button);
            minionGUI.drawInfoPanelGUI();
        }

		public void createMinion(Engine.Minions.Minion minion)
		{
			IMinionGUI gui = (IMinionGUI)Activator.CreateInstance(Type.GetType("Assets.Scripts.GUI.Minions." + minion.GetType().Name + "GUI, Assembly-CSharp"));
			minionGUIs.AddLast(gui);
			gui.createMinion(minion);
		}
		
		public void addMinionEffect(Engine.Minions.Minion minion, Engine.Effects.MinionEffects.MinionEffect effect)
		{
            Type guiType = Type.GetType("Assets.Scripts.GUI.MinionEffects." + effect.GetType().Name + "GUI, Assembly-CSharp");
            if (guiType != null)
            {
                IMinionEffectGUI gui = (IMinionEffectGUI)Activator.CreateInstance(guiType);
                minionEffectGUIs.AddLast(gui);
                gui.createMinionEffect(minion, effect);
            }
		}
		
		public void minionHit(Engine.Minions.Minion minion, Engine.Missiles.Missile missile)
		{
			// TODO
		}

        public void minionDied(Engine.Minions.Minion minion)
        {
            IMinionGUI gui = (IMinionGUI)minion.tag;
            gui.onMinionDied();
        }
		public void destroyMinion(Engine.Minions.Minion minion)
		{
			// TODO suanda can 0 oldugunda olduruyoruz, destroyMinion bilgisini pek sallamiyoruz.
		}


		public void createMissile(Engine.Missiles.Missile missile)
		{
			IMissileGUI gui = (IMissileGUI)Activator.CreateInstance(Type.GetType("Assets.Scripts.GUI.Missiles." + missile.GetType().Name + "GUI, Assembly-CSharp"));
			missileGUIs.AddLast(gui);
			gui.createMissile(missile);
		}
		
		public void destroyMissile(Engine.Missiles.Missile missile)
		{
			// TODO hedefe ulasinca missile i siliyoruz, o yuzden bu metod bos
		}
		
		public void createAreaEffect(Engine.AreaEffects.AreaEffect areaEffect)
		{
            IAreaEffectGUI gui = (IAreaEffectGUI)Activator.CreateInstance(Type.GetType("Assets.Scripts.GUI.AreaEffects." + areaEffect.GetType().Name + "GUI, Assembly-CSharp"));
            areaEffectGUIs.AddLast(gui);
            gui.createAreaEffect(areaEffect);
		}
		
		public void destroyAreaEffect(Engine.AreaEffects.AreaEffect areaEffect)
		{            
		}
		
		public void skillCooldownEnded(Engine.Skills.Skill skill)
		{
			// TODO
		}
		
		public void skillActivated(Engine.Skills.Skill skill)
		{
			// TODO
		}

        public void minion_quantumSoldier_teleport(Minion minion)
        {
            if (minion.tag != null && minion.tag is Assets.Scripts.GUI.Minions.QuantumSoldierMinionGUI)
            {
                ((Assets.Scripts.GUI.Minions.QuantumSoldierMinionGUI)minion.tag).teleport();
            }
        }

        public void minion_frankenScientist_spawn(FrankenScientistMinion parentMinion, ScrapGolemMinion spawnedMinion)
        {
            createMinion(spawnedMinion);
        }

        public void minion_frankenScientist_stackChanged(FrankenScientistMinion minion, int stackCount)
        {
            if (minion.tag != null)
            {
                FrankenScientistMinionGUI gui = minion.tag as FrankenScientistMinionGUI;
                if( gui != null)
                    gui.updateStackCount(stackCount);
            }
        }

        public void minion_zombie_raise(ZombieMinion zombieMinion)
        {
            if (zombieMinion.tag != null)
                (zombieMinion.tag as ZombieMinionGUI).onMinionRaise();
        }

	    void IGraphics.minion_mutantEightLegged_spawn(MutantEightLeggedMinion parentMinion, ICollection<MutantEightLeggedSpawningMinion> spawnings)
	    {
	        foreach (var spawning in spawnings)
                createMinion(spawning);
	    }
		public void displayGameChatMessage(string senderUsername, string message)
		{
            uiControllerGame.showChatMessage(senderUsername + ": " + message);

		}

		public void displayEndGameStatistics()
		{
            uiControllerGame.initializeEndGameStatsPanel();
		}

		#endregion

	}
}

