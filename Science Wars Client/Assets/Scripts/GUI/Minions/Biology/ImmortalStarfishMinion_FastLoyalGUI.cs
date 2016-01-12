using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.GUI.Minions
{
    class ImmortalStarfishMinion_FastLoyalGUI : ImmortalStarfishMinion_LoyalGUI
    {
        public ImmortalStarfishMinion_FastLoyalGUI()
            : base(typeof(ImmortalStarfishMinion_FastLoyal))	
		{
		}

        public override string getInfo()
        {
            return "Upon dying divides herself into 5 " + makeInfoString("Fast Durable Child Starfishes") + " with 150 health and 1.4 movement speed.";
        }

        public override string getUpgradeInfo()
        {
            return "Now spawns childs with " + makePositiveString("1.4") + " movement speed.";
        }
    }
}
