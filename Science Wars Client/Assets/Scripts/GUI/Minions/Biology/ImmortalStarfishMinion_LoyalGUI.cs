using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.GUI.Minions
{
    class ImmortalStarfishMinion_LoyalGUI : ImmortalStarfishMinionGUI
    {
        public ImmortalStarfishMinion_LoyalGUI()
            : base(typeof(ImmortalStarfishMinion_Loyal))	
		{
		}

        public ImmortalStarfishMinion_LoyalGUI(Type minionType)
            : base(minionType)
        {
        }

        public override string getInfo()
        {
            return "Upon dying divides herself into 5 " + makeInfoString("Durable Child Starfishes") + " with 150 health and 1.3 movement speed.";
       }

        public override string getUpgradeInfo()
        {
            return "Now spawns childs with " + makePositiveString("150") + " health points.";
        }
    }
}
