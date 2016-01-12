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
	
	public class MutantEightLeggedMinionGUI : MinionGUIImp
	{
		
		private static GameObject staticMinionObject;
		private static Texture2D staticMinionIcon;
		private static Texture2D staticMinionInfo;
		private static Projector staticRangeProjector;

        public MutantEightLeggedMinionGUI()
            : base(typeof(MutantEightLeggedMinion))	
		{
			if (staticMinionObject != null) 
			{
				childStaticMinionObject = staticMinionObject;
				childStaticMinionIcon = staticMinionIcon;
				childStaticMinionInfo = staticMinionInfo;
				childStaticRangeProjector = staticRangeProjector;
			}
		}

        public MutantEightLeggedMinionGUI(Type minionType)
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

        public override string getInfo()
        {
            return "Mutant Eight Legged can create unlimited number of spawning from nearby dead bodies. Each spawning has " + makePositiveString("220") + 
                " health points, " + makePositiveString("0.9") + " movement speed and " + makePositiveString("0") + " health cost.";
        }

        public override string getUpgradeInfo()
        {
            return "";
        }
		
		#region IRequiresResourceGUI implementation
		
		public override void loadResources ()
		{
			staticMinionObject = (GameObject)Resources.Load("3Ds/Minions/Biology/MutantEightLeggedMinion/MinionObject");
            staticMinionIcon = Resources.Load<Texture2D>("3Ds/Minions/Biology/MutantEightLeggedMinion/GUI/minionIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
		}
		
		#endregion
		
	
	}
}