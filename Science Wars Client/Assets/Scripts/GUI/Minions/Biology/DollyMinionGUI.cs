using System.Net.Configuration;
using System.Security.Cryptography;
using UnityEngine;
using System.Collections;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.Minions.Biology;
using System;

namespace Assets.Scripts.GUI.Minions
{
	public class DollyMinionGUI : MinionGUIImp
	{
		private static GameObject staticMinionObject;
		private static Texture2D staticMinionIcon;
		private static Texture2D staticMinionInfo;
		private static Projector staticRangeProjector;
		

		
		public DollyMinionGUI() : base(typeof(DollyMinion))	
		{
			if (staticMinionObject != null) 
			{
				childStaticMinionObject = staticMinionObject;
				childStaticMinionIcon = staticMinionIcon;
				childStaticMinionInfo = staticMinionInfo;
				childStaticRangeProjector = staticRangeProjector;
			}
		}
		
        public DollyMinionGUI(Type minionType)
            : base(minionType)
        {
            if (staticMinionObject != null)
            {
                childStaticMinionObject = staticMinionObject;
                childStaticMinionIcon = staticMinionIcon;
                childStaticMinionInfo = staticMinionInfo;
                childStaticRangeProjector = staticRangeProjector;
            }
        }
		
		public override void loadResources ()
		{
			staticMinionObject = (GameObject)Resources.Load("3Ds/Minions/Biology/DollyMinion/MinionObject"); 
			staticMinionIcon = Resources.Load<Texture2D>("3Ds/Minions/Biology/DollyMinion/GUI/minionIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
		}
		
        public override string getInfo()
        {
            return "Dolly clones himself in every 5 seconds up to 2 copies, his clones also can clone himself but they should be in less level 3 in the clone family tree.";
        }
		
        public override string getUpgradeInfo()
        {
            return "";
	}

		
	}
}