using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.Towers.Chemistry;
using Assets.Scripts.GUI.GUIUtilities;


namespace Assets.Scripts.GUI.Towers
{
	public abstract class TowerGUIImp : ITowerGUI
	{
		// these are used to store static variables of the child class.
		// her kule icin 4 * 4 = 16 byte fazlalik demek ama kod kopyala yapistirin onune geciyor iyi bence.
		protected GameObject childStaticTowerObject;
		protected Texture2D childStaticTowerIcon;
		protected Texture2D childStaticTowerInfo;
		protected Projector childStaticRangeProjector;

	    protected AudioSource soundPlayer;
	    protected AudioClip staticCreateSound;

		protected Tower tower;
		protected Type towerType;
		protected bool destroyable = false;

		protected GameObject towerObject;
		protected Projector rangeProjector;

        public static string positiveColor = "[22EE22]";
        public static string negativeColor = "[EE2222]";
        public static string infoColor = "[FFAA00]";

		private static Shader shader = Shader.Find("Unlit/Transparent Cutout");

		public TowerGUIImp(Type towerType)
		{
			this.towerType = towerType;
		}

        public static string makePositiveString(string text)
        {
            return "[22EE22]" + text + "[-]";
        }

        public static string makeNegativeString(string text)
        {
            return "[EE2222]" + text + "[-]";
        }

        public static string makeInfoString(string text)
        {
            return "[FFAA00]" + text + "[-]";
        }

	    public abstract void loadResources();

		public virtual void createTower (Tower t)
		{
			tower = t;
			t.tag = this;

			towerObject = (GameObject)GameObject.Instantiate(childStaticTowerObject);
			towerObject.name = "t_" + tower.board.instanceId + "_" + tower.indexOnBoard;
			towerObject.transform.position = tower.board.getTowerPosition(tower.indexOnBoard);
			
			rangeProjector = (Projector)GameObject.Instantiate(childStaticRangeProjector);
			rangeProjector.transform.parent = towerObject.transform;
			rangeProjector.transform.localPosition = new Vector3(0, 0.2f, 0);
			rangeProjector.orthographicSize = tower.stats.baseRange;
			rangeProjector.enabled = false;

            GameObject.Instantiate(UIControllerGame.getInstance().createTowerEffect, towerObject.transform.position, Quaternion.identity);

		    soundPlayer = towerObject.AddComponent<AudioSource>();
		    soundPlayer.volume = 1;
		    soundPlayer.PlayOneShot((AudioClip)Resources.Load("Sound/tower_build"));
		}

		public virtual void step()
		{
			if(destroyable == false)
			{
				if (tower.destroyable == true || tower.board.boardState == Board.BoardState.COLLAPSING)
					destroyTower();
				else
					towerObject.transform.position = tower.getWorldPosition();//board.getTowerPosition(tower.indexOnBoard);
			}
		}

        public virtual string getInfo()
        {
            return "Tower Info";
        }

        public virtual string getUpgradeInfo()
        {
            if (tower != null)
                return  "[FFAA00]     " + tower.getName() + "[-]\n" +
                        "[FFFFFF]   Cost: " + tower.getCost() + "\n" +
                                "   Range: " + tower.getRange() * 100 + "\n" +
                                "   Attack CD: " + tower.getAttackCooldown() + "[-]";
            else
                return "Tower Upgrade Info";
        }

		public virtual void drawCreateTowerButtonGUI(GameObject button)
		{
			// burasi les
			UITexture texture = button.GetComponentsInChildren<UITexture>(true)[0];
			Material mat = new Material(shader);
			mat.mainTexture = childStaticTowerIcon;
			texture.material = mat;
		}
		
		public virtual void drawInfoPanelGUI()
		{
			UIControllerGame controller = UIControllerGame.getInstance();
			Tower towerTmp;
			if (this.tower == null)	//gercek bir kule degil demek. ikonlari gostermek icin vs. tutulan dummy kule demek.
				towerTmp = TypeIdGenerator.getTowerInsts (TypeIdGenerator.getTowerId(this.towerType));
			else
				towerTmp = this.tower;
			controller.label_TowerCost.text = towerTmp.getCost().ToString();
			controller.label_TowerTitle.text = towerTmp.getName();
			controller.label_TowerDescription.text = getInfo();
			controller.label_TowerAttackCD.text = towerTmp.getAttackCooldown().ToString();
			controller.label_TowerRange.text = (towerTmp.getRange() * 100 ).ToString();
			controller.sprite_TowerIcon.mainTexture = childStaticTowerIcon;


			//remove all upgrade buttons remaining from previous
			var children = new List<GameObject>();
			foreach (Transform child in controller.panel_UpgradeTowerContainer.transform) children.Add(child.gameObject);
			children.ForEach(child => GameObject.Destroy(child));

			// eger bu cizim sadece bilgi gostermek icinse veya bu kule sana aitse upgrade'leri ekle
            if (this.tower == null || this.tower.board == PlayerMe.self.board)
            {
                var i = 0;
                foreach (TowerNode node in TypeIdGenerator.getTowerNodeInsts(towerType).children)
                {
                    if (UserMe.unlockedTowers[TypeIdGenerator.getTowerId(node.towerType)])
                    {
                        Tower child = TypeIdGenerator.getTowerInsts(TypeIdGenerator.getTowerId(node.towerType));
                        ITowerGUI childGUI = TypeIdGeneratorGUI.towerGuiInst[TypeIdGenerator.getTowerId(node.towerType)];

                        GameObject button = (GameObject)GameObject.Instantiate(controller.button_UpgradeTowerSample);
                        button.transform.parent = controller.panel_UpgradeTowerContainer.transform;
                        button.transform.localScale = new Vector3(1, 1, 1);
                        button.transform.localPosition = controller.button_UpgradeTowerSample.transform.localPosition + new Vector3(60 * i, 0, 0);

                        button.GetComponentsInChildren<UIButtonMessage>(true)[0].parameter = TypeIdGenerator.getTowerId(towerType).ToString() + " " + TypeIdGenerator.getTowerId(node.towerType).ToString();

                        button.GetComponentsInChildren<UILabel>(true)[0].text = child.getCost().ToString();
                        button.GetComponentsInChildren<Tooltiper>(true)[0].text = childGUI.getUpgradeInfo();
                        childGUI.drawCreateTowerButtonGUI(button);

                        if (child.getCost() > PlayerMe.cash)
                            button.GetComponentsInChildren<UISlicedSprite>(true)[0].color = Color.red;

                        button.SetActive(true);
                        i++;
                    }
                }
            }

			controller.panel_TowerInfo.SetActive(true);
		}
		
		public virtual void drawUpgradeInfoPanelGUI(Rect rectangle)
		{
			// TODO
		}

		public virtual void destroyTower()
		{
			destroyable = true;
			GameObject.Destroy(towerObject);
		}

		public virtual void onTowerSelected()
		{
			if (rangeProjector != null)
				rangeProjector.enabled = true;
		}
		
		public virtual void onTowerUnselected()
		{
			if (rangeProjector != null)
				rangeProjector.enabled = false;
		}
		
		public virtual bool isDestroyable()
		{
			return destroyable;
		}
		
		public virtual void addEffect(Engine.Effects.TowerEffects.ITowerEffect effect)
		{
			// TODO
		}

        public Tower getTower()
        {
            return tower;
        }
	}
}
