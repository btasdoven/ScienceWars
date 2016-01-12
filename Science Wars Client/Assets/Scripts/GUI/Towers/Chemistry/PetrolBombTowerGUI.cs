using System;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Engine;
using Assets.Scripts.GUI;
using Assets.Scripts.Engine.Towers.Chemistry;

namespace Assets.Scripts.GUI.Towers
{
	public class PetrolBombTowerGUI : TowerGUIImp
	{
		private static GameObject staticTowerObject;
		private static Texture2D staticTowerIcon;
		private static Texture2D staticTowerInfo;
		private static Projector staticRangeProjector;
		
		public PetrolBombTowerGUI() : base(typeof(PetrolBombTower))	
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
            return "This tower sends a petrol bomb which deals 110 fire damage over time.";
        }
		
		//assign edilen objeler statik olmali
		public override void loadResources()
		{
            staticTowerObject = (GameObject)Resources.Load("3Ds/Towers/Chemistry/PetrolBombTower/TowerObject");
            staticTowerIcon = (Texture2D)Resources.Load("3Ds/Towers/Chemistry/PetrolBombTower/GUI/towerIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
            staticCreateSound = (AudioClip)Resources.Load("Sound/tower_build");
		}
	}
}

