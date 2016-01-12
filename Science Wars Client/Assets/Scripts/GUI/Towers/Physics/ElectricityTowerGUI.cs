using System;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Engine;
using Assets.Scripts.GUI;
using Assets.Scripts.Engine.Towers.Physics;


namespace Assets.Scripts.GUI.Towers
{
	public class ElectricityTowerGUI : TowerGUIImp
	{
		private static GameObject staticTowerObject;
		private static Texture2D staticTowerIcon ;
		private static Texture2D staticTowerInfo;
		private static Projector staticRangeProjector;
		
		public ElectricityTowerGUI() : base(typeof(ElectricityTower))	
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
            return "This tower hits 8 minions at the same time.";
        }
		
		//assign edilen objeler statik olmali
		public override void loadResources()
		{
            staticTowerObject = (GameObject)Resources.Load("3Ds/Towers/Physics/ElectricityTower/TowerObject");
            staticTowerIcon = Resources.Load<Texture2D>("3Ds/Towers/Physics/ElectricityTower/GUI/towerIcon");
            staticCreateSound = (AudioClip)Resources.Load("Sound/tower_build");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
		}
	}
}

