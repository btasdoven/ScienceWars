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
	
	public class MutantEightLeggedSpawningMinionGUI : MinionGUIImp
	{
		
		private static GameObject staticMinionObject;
		private static Texture2D staticMinionIcon;
		private static Texture2D staticMinionInfo;
		private static Projector staticRangeProjector;

        public MutantEightLeggedSpawningMinionGUI()
            : base(typeof(MutantEightLeggedSpawningMinion))	
		{
			if (staticMinionObject != null) 
			{
				childStaticMinionObject = staticMinionObject;
				childStaticMinionIcon = staticMinionIcon;
				childStaticMinionInfo = staticMinionInfo;
				childStaticRangeProjector = staticRangeProjector;
			}
		}

        public MutantEightLeggedSpawningMinionGUI(Type minionType)
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
            return "This minion can only be spawned by the Mutant Eight Legged minion.";
        }

        public override string getUpgradeInfo()
        {
            return "";
        }
		
		#region IRequiresResourceGUI implementation
		
		public override void loadResources ()
		{
            staticMinionObject = (GameObject)Resources.Load("3Ds/Minions/Biology/MutantEightLeggedSpawningMinion/MinionObject");
            staticMinionIcon = Resources.Load<Texture2D>("3Ds/Minions/Biology/MutantEightLeggedSpawningMinion/GUI/minionIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
		}
		
		#endregion
		
	
	}
}