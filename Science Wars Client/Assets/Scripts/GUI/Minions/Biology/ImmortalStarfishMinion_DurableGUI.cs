using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.GUI.Minions
{
    class ImmortalStarfishMinion_DurableGUI : ImmortalStarfishMinionGUI
    {
         public ImmortalStarfishMinion_DurableGUI()
            : base(typeof(ImmortalStarfishMinion_Durable))	
		{
		}

         public ImmortalStarfishMinion_DurableGUI(Type minionType)
            : base(minionType)
        {
        }

        public override string getInfo()
        {
            return "Upon dying divides herself into 5 " + makeInfoString("Child Starfishes") + " with 130 health and 1.3 movement speed.";
       }

        public override string getUpgradeInfo()
        {
            return "Now has " + makePositiveString("%30") + " " + makeInfoString("Poison") +  " resistance.";
        }
    }
}
