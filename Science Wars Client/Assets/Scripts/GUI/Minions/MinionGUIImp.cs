using Assets.Scripts.Engine.Minions;
using Assets.Scripts.GUI.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.GUI.GUIUtilities;


namespace Assets.Scripts.GUI.Minions
{
	public abstract class MinionGUIImp : IMinionGUI
	{
		protected GameObject childStaticMinionObject;
		protected Texture2D childStaticMinionIcon;
		protected Texture2D childStaticMinionInfo;
		protected Projector childStaticRangeProjector;
	    
        protected AudioSource soundPlayer;
	    protected AudioClip deathSound;
        protected AudioClip spawnSound;

		protected Assets.Scripts.Engine.Minions.Minion minion;
		protected Type minionType;
		protected bool destroyable = false;
			
		protected GameObject minionObject;
		protected Projector rangeProjector;
		protected HealthBarDrawer healthBar;
		protected Animation[] animations;

        public abstract void loadResources();

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

		static private Shader shader = Shader.Find("Unlit/Transparent Cutout");

		public MinionGUIImp (Type minionType)
		{
			this.minionType = minionType;
		}	

		#region IMinionGUI implementation

        public virtual string getInfo()
        {
            return "Minion Info";
        }

        public virtual string getUpgradeInfo()
        {
            if (minion != null)
                return  "[FFAA00]     " + minion.getName() + "[-]\n" +
                        "[FFFFFF]   Cost: " + minion.getCost() + "\n" +
                        "   Income: " + minion.getIncome() + "\n" +
                        "   Health: " + minion.stats.healthTotal + "\n" +
                        "   MS: " + minion.stats.baseMovementSpeed + "[-]";
            else
                return "Minion Upgrade Info";
        }

		public virtual void createMinion (Assets.Scripts.Engine.Minions.Minion minion)
		{
			this.minion = minion;
			minion.tag = this;
			minionObject = (GameObject)GameObject.Instantiate(childStaticMinionObject);
			minionObject.name = "m_" + minion.instanceId;
			
            healthBar = minionObject.transform.FindChild("HealthBar").gameObject.GetComponent<HealthBarDrawer>();
		    if (healthBar != null)
		    {
		        healthBar.health = (int) minion.stats.health;
		        healthBar.maxHealth = (int) minion.stats.healthTotal;
		    }


		    animations = (Animation[]) minionObject.GetComponentsInChildren<Animation>();
            foreach (Animation animation in animations)
                if(animation["walk"] != null)
			        animation["walk"].speed = minion.stats.baseMovementSpeed * walkAnimationSpeedMultiplier();

			rangeProjector = (Projector)GameObject.Instantiate(childStaticRangeProjector);
			rangeProjector.transform.parent = minionObject.transform;
			rangeProjector.transform.localPosition = new Vector3(0, 0.2f, 0);
			rangeProjector.orthographicSize = 0.2f;
			rangeProjector.enabled = false;

		    soundPlayer = minionObject.AddComponent<AudioSource>();
		    soundPlayer.volume = 2;
            soundPlayer.rolloffMode = AudioRolloffMode.Linear;
		    if (spawnSound == null)
		        spawnSound = Resources.Load<AudioClip>("Sound/minion_spawn");
		    soundPlayer.clip = spawnSound;
            soundPlayer.Play();
		}

	    public virtual float walkAnimationSpeedMultiplier()
	    {
	        return 2.0f;
	    }
		public virtual void addEffect (Assets.Scripts.Engine.Effects.MinionEffects.MinionEffect effect)
		{
			// TODO
		}

		public virtual void destroyMinion ()
		{
			destroyable = true;
            GameObject.Destroy(minionObject);//GameObject.Destroy(minionObject, animation["death"].length + 0.5f);
			minion = null;
		}

		public virtual bool isDestroyable()
		{
			return destroyable;
		}

        public virtual void onMinionDied()
        {
            foreach (var animation in animations)
            {
                animation.enabled = true;
                animation.CrossFade("death");
                
                if( deathSound != null)
                    soundPlayer.PlayOneShot(deathSound);
            }
            
        }

		public virtual void onMinionSelected()
		{
			if (rangeProjector != null)
				rangeProjector.enabled = true;
		}
			
		public virtual void onMinionUnselected()
		{
			if (rangeProjector != null)
				rangeProjector.enabled = false;
		}

		public virtual void drawCreateMinionButtonGUI (GameObject button)
		{
		    // burasi les
		    UITexture texture = button.GetComponentsInChildren<UITexture>(true)[0];
		    Material mat = new Material(shader);
		    mat.mainTexture = childStaticMinionIcon;
		    texture.material = mat;
		}

		public virtual void drawInfoPanelGUI ()
		{
			UIControllerGame controller = UIControllerGame.getInstance();

			Minion minion;
			if (this.minion == null)
				minion = TypeIdGenerator.getMinionInsts (TypeIdGenerator.getMinionId(this.minionType));
			else
				minion = this.minion;
				
			controller.label_MinionCost.text = minion.getCost().ToString();
			controller.label_MinionFireRes.text = "-";
			controller.label_MinionPhysRes.text = "-";
			controller.label_MinionPoisonRes.text = "-";
			controller.label_MinionIncome.text = minion.getIncome().ToString();
			controller.label_MinionReward.text = minion.getKillGold().ToString();
			controller.label_MinionHealth.text = minion.stats.healthTotal.ToString();
			controller.label_MinionMS.text = minion.stats.baseMovementSpeed.ToString();	
			controller.label_MinionTitle.text = minion.getName();
            controller.label_MinionDescription.text = getInfo();
			controller.sprite_MinionIcon.mainTexture = childStaticMinionIcon;

			//remove all upgrade buttons remaining from previous
			var children = new List<GameObject>();
			foreach (Transform child in controller.panel_UpgradeMinionContainer.transform) children.Add(child.gameObject);
			children.ForEach(child => GameObject.Destroy(child));
				
			// eger bu cizim sadece bilgi gostermek icinse veya bu minion sana aitse upgrade'leri ekle
            if (this.minion == null)
            {
			    var i = 0;
			    foreach (MinionNode node in TypeIdGenerator.getMinionNodeInsts(minionType).children) {
                    if (UserMe.unlockedMinions[TypeIdGenerator.getMinionId(node.minionType)])
                    {
                        Minion child = TypeIdGenerator.getMinionInsts(TypeIdGenerator.getMinionId(node.minionType));
                        IMinionGUI childGUI = TypeIdGeneratorGUI.minionGuiInst[TypeIdGenerator.getMinionId(node.minionType)];

                        GameObject button = (GameObject)GameObject.Instantiate(controller.button_UpgradeMinionSample);
                        button.transform.parent = controller.panel_UpgradeMinionContainer.transform;
                        button.transform.localScale = new Vector3(1, 1, 1);
                        button.transform.localPosition = controller.button_UpgradeMinionSample.transform.localPosition + new Vector3(60 * i, 0, 0);


                        button.GetComponentsInChildren<UILabel>(true)[0].text = child.getUpgradeCost().ToString();
                        button.GetComponentsInChildren<Tooltiper>(true)[0].text = childGUI.getUpgradeInfo();
                        childGUI.drawCreateMinionButtonGUI(button);

                        UIButtonMessage msg = button.GetComponentsInChildren<UIButtonMessage>(true)[0];
                        if (child.getCost() > PlayerMe.cash)
                        {
                            button.GetComponentsInChildren<UISlicedSprite>(true)[0].color = Color.red;
                            button.GetComponentsInChildren<UIButtonColor>(true)[0].enabled = false;
                            msg.enabled = false;
                        }
                        else
                            msg.parameter = TypeIdGenerator.getMinionId(minionType).ToString() + " " + TypeIdGenerator.getMinionId(node.minionType).ToString();

                        button.SetActive(true);
                        i++;
                    }
			    }
            }

			controller.panel_MinionInfo.SetActive(true);
		}

		public virtual void drawUpgradeInfoPanelGUI (Rect rectangle)
		{
			// TODO
		}

		#endregion

			

		#region IStep implementation

		public virtual void step ()
		{
			if (destroyable == false)
			{
                minionObject.transform.position = minion.getWorldPosition();
                minionObject.transform.rotation =
                    Quaternion.Euler(
                        Quaternion.LookRotation(
                        minion.position.board.getPath().findDiffOnPath(minion.position.pathPosition),
                        new Vector3(0, 1, 0)).eulerAngles + minion.position.board.rotation);

                if (minion.stats.movementDirection < 0)
                    minionObject.transform.RotateAround(minionObject.transform.position, 
                                                        minionObject.transform.up, 
                                                        180.0f);

                //healthBar.transform.localScale = new Vector3( Mathf.Max(0,0.01f * minion.stats.health / minion.stats.healthTotal), 0, 0.001f);
                if (healthBar != null)
			    {
			        healthBar.transform.LookAt(Camera.main.transform.position, new Vector3(0, 1, 0));
			        healthBar.transform.rotation = Quaternion.Euler(healthBar.transform.rotation.eulerAngles + new Vector3(90, 0, 0));

			        healthBar.health = (int) minion.stats.health;
			        healthBar.maxHealth = (int) minion.stats.healthTotal;
			    }


			    if (minion.destroyable == true)
					destroyMinion();
			}
		}

		#endregion

	}
}

