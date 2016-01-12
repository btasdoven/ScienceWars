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
	public class BallistaTowerGUI : TowerGUIImp
	{
		private static GameObject staticTowerObject;
		private static Texture2D staticTowerIcon;
		private static Projector staticRangeProjector;

		public BallistaTowerGUI() : base(typeof(BallistaTower))	
		{
			if (staticTowerObject != null) 
			{
				childStaticTowerObject = staticTowerObject;
				childStaticTowerIcon = staticTowerIcon;
				childStaticRangeProjector = staticRangeProjector;
			}
		}

		protected BallistaTowerGUI(Type towerType)
			: base(towerType)
		{
			if (staticTowerObject != null)
			{
				childStaticTowerObject = staticTowerObject;
				childStaticTowerIcon = staticTowerIcon;
				childStaticRangeProjector = staticRangeProjector;
			}
		}

        public override string getInfo()
        {
            return "This tower firing a bolt to a single target in medium range.";
        }

		public override string getUpgradeInfo()
		{
			return "";
		}

		//assign edilen objeler statik olmali
		public override void loadResources()
		{
			staticTowerObject = (GameObject)Resources.Load("3Ds/Towers/Physics/BallistaTower/TowerObject");            
			staticTowerIcon = (Texture2D)Resources.Load("3Ds/Towers/Physics/BallistaTower/GUI/towerIcon");
		    staticCreateSound = (AudioClip) Resources.Load("Sound/tower_build");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
		}
    }
}

