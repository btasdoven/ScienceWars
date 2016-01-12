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
	public class TeslaTowerGUI : TowerGUIImp
	{
		private static GameObject staticTowerObject;
		private static Texture2D staticTowerIcon;
		private static Texture2D staticTowerInfo;
		private static Projector staticRangeProjector;
		
		public TeslaTowerGUI() : base(typeof(TeslaTower))	
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
            return "This tower attacks all minions in the range.";
        }
		
		//assign edilen objeler statik olmali
		public override void loadResources()
		{
			staticTowerObject = (GameObject)Resources.Load("3Ds/Towers/Physics/TeslaTower/TowerObject");            
			staticTowerIcon = (Texture2D)Resources.Load("3Ds/Towers/Physics/TeslaTower/GUI/towerIcon");
            staticCreateSound = (AudioClip)Resources.Load("Sound/tower_build");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
		}
	}
}

