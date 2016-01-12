using System.Net.Configuration;
using System.Security.Cryptography;
using UnityEngine;
using System.Collections;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.Minions.Chemistry;
using System;

namespace Assets.Scripts.GUI.Minions
{
	public class ChemistryStudentMinionGUI : MinionGUIImp
	{
		private static GameObject staticMinionObject;
		private static Texture2D staticMinionIcon;
		private static Texture2D staticMinionInfo;
		private static Projector staticRangeProjector;
		

		public ChemistryStudentMinionGUI() : base(typeof(ChemistryStudentMinion))	
		{
			if (staticMinionObject != null) 
			{
				childStaticMinionObject = staticMinionObject;
				childStaticMinionIcon = staticMinionIcon;
				childStaticMinionInfo = staticMinionInfo;
				childStaticRangeProjector = staticRangeProjector;
			}
		}

        public ChemistryStudentMinionGUI(Type minionType)
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
            return "Chemistry Student is the most basic minion in the " + makeInfoString("Chemistry") + " science.";
        }

        public override string getUpgradeInfo()
        {
            return "";
        }
		
		#region IRequiresResourceGUI implementation
		
		public override void loadResources ()
		{
			staticMinionObject = (GameObject)Resources.Load("3Ds/Minions/Chemistry/ChemistryStudentMinion/MinionObject"); 
			staticMinionIcon = Resources.Load<Texture2D>("3Ds/Minions/Chemistry/ChemistryStudentMinion/GUI/minionIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
		}
		
		#endregion
		

	}
}