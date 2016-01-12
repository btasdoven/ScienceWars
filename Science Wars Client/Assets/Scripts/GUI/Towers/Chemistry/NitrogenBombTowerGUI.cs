using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.Towers.Chemistry;
namespace Assets.Scripts.GUI.Towers
{
	public class NitrogenBombTowerGUI : TowerGUIImp
	{
		private static GameObject staticTowerObject;
		private static Texture2D staticTowerIcon;
		private static Texture2D staticTowerInfo;
		private static Projector staticRangeProjector;
		
		public NitrogenBombTowerGUI() : base(typeof(NitrogenBombTower))	
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
            return "This tower has a normal range and slow attack speed. However it can freeze minions and decreases armors.";
        }

		//assign edilen objeler statik olmali
		public override void loadResources()
		{
			staticTowerObject = (GameObject)Resources.Load("3Ds/Towers/Chemistry/NitrogenBombTower/TowerObject");            
			staticTowerIcon = (Texture2D)Resources.Load("3Ds/Towers/Chemistry/NitrogenBombTower/GUI/towerIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
            staticCreateSound = (AudioClip)Resources.Load("Sound/tower_build");
		}
	}
}
