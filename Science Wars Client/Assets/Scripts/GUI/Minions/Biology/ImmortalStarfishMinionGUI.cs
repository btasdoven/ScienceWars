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

    public class ImmortalStarfishMinionGUI : MinionGUIImp
    {

		private static GameObject staticMinionObject;
		private static Texture2D staticMinionIcon;
		private static Texture2D staticMinionInfo;
		private static Projector staticRangeProjector;


		public ImmortalStarfishMinionGUI() : base(typeof(ImmortalStarfishMinion))	
		{
			if (staticMinionObject != null) 
			{
				childStaticMinionObject = staticMinionObject;
				childStaticMinionIcon = staticMinionIcon;
				childStaticMinionInfo = staticMinionInfo;
				childStaticRangeProjector = staticRangeProjector;
			}
		}

        public ImmortalStarfishMinionGUI(Type minionType)
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
            return "Upon dying divides herself into 5 " + makeInfoString("Child Starfishes") + " with 130 health and 1.3 movement speed.";
        }

        public override string getUpgradeInfo()
        {
            return "";
        }


		#region IRequiresResourceGUI implementation

		public override void loadResources ()
		{
			staticMinionObject = (GameObject)Resources.Load("3Ds/Minions/Biology/ImmortalStarfishMinion/MinionObject");            
			staticMinionIcon = Resources.Load<Texture2D>("3Ds/Minions/Biology/ImmortalStarfishMinion/GUI/minionIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
		}

		#endregion

	    
    }
}