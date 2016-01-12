using Assets.Scripts.Engine.Towers.Chemistry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GUI.Towers
{
    class TrypanophobiaTower_FasterGUI : TowerGUIImp
	{
		private static GameObject staticTowerObject;
		private static Texture2D staticTowerIcon;
		private static Texture2D staticTowerInfo;
		private static Projector staticRangeProjector;

        public TrypanophobiaTower_FasterGUI()
            : base(typeof(TrypanophobiaTower_Faster))	
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
            return "This tower frightens a minion and it starts to run back for a while.";
        }
		
		//assign edilen objeler statik olmali
		public override void loadResources()
		{
            staticTowerObject = (GameObject)Resources.Load("3Ds/Towers/Chemistry/TrypanophobiaTower/TowerObject");
            staticTowerIcon = (Texture2D)Resources.Load("3Ds/Towers/Chemistry/TrypanophobiaTower/GUI/towerIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
            staticCreateSound = (AudioClip)Resources.Load("Sound/tower_build");
		}
    }
}
