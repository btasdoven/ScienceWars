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
	public class BlackHoleTowerGUI : TowerGUIImp
	{
		private static GameObject staticTowerObject;
		private static Texture2D staticTowerIcon;
		private static Texture2D staticTowerInfo;
		private static Projector staticRangeProjector;

        public static GameObject teleportStartEffectObject;
        public static GameObject teleportEndEffectObject;

		public BlackHoleTowerGUI() : base(typeof(BlackHoleTower))	
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
            return "This tower has a huge range however slow attack speed and missile speed.";
        }

		//assign edilen objeler statik olmali
		public override void loadResources()
		{
            staticTowerObject = (GameObject)Resources.Load("3Ds/Towers/Physics/BlackHoleTower/TowerObject");
            staticTowerIcon = (Texture2D)Resources.Load("3Ds/Towers/Physics/BlackHoleTower/GUI/towerIcon");
            staticCreateSound = (AudioClip)Resources.Load("Sound/tower_build");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
            teleportStartEffectObject = (GameObject)Resources.Load("3Ds/Towers/Physics/BlackHoleTower/teleportStartEffectObject");
            teleportEndEffectObject = (GameObject)Resources.Load("3Ds/Towers/Physics/BlackHoleTower/teleportEndEffectObject");
		}
    }
}

