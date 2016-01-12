using System;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Engine;
using Assets.Scripts.GUI;
using Assets.Scripts.Engine.Towers.Biology;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.GUI.Towers
{
	public class DroseraTowerGUI : TowerGUIImp
	{
		private static GameObject staticTowerObject;
		private static Texture2D staticTowerIcon;
		private static Texture2D staticTowerInfo;
		private static Projector staticRangeProjector;
        private static GameObject biteEffectObject;

		public DroseraTowerGUI() : base(typeof(DroseraTower))
		{
			if (staticTowerObject != null) 
			{
				childStaticTowerObject = staticTowerObject;
				childStaticTowerIcon = staticTowerIcon;
				childStaticTowerInfo = staticTowerInfo;
				childStaticRangeProjector = staticRangeProjector;
			}
		}
		
		protected DroseraTowerGUI(Type towerType)
			: base(towerType)
		{
			if (staticTowerObject != null)
			{
				childStaticTowerObject = staticTowerObject;
				childStaticTowerIcon = staticTowerIcon;
				childStaticTowerInfo = staticTowerInfo;
				childStaticRangeProjector = staticRangeProjector;
			}
		}
		
		public override string getInfo()
		{
			return "This gigantic plant can eat any minion have lifepoint less than 500 and consume it over 120 health per second. After digestion it is ready to attack again!";
		}
		
		//assign edilen objeler statik olmali
		public override void loadResources()
		{
			staticTowerObject = (GameObject)Resources.Load("3Ds/Towers/Biology/DroseraTower/TowerObject");            
			staticTowerIcon = (Texture2D)Resources.Load("3Ds/Towers/Biology/DroseraTower/GUI/towerIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
            biteEffectObject = (GameObject)Resources.Load("3Ds/Towers/Biology/DroseraTower/biteEffectObject");
            staticCreateSound = (AudioClip)Resources.Load("Sound/tower_build");
		}

        public void biteMinion(Minion minion)
        {
            GameObject.Instantiate(biteEffectObject, minion.getWorldHeadPosition(), Quaternion.identity);
        }
    }
}
