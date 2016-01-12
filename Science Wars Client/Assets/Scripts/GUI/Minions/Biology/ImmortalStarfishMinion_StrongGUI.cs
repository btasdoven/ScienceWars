using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.GUI.Minions
{
    class ImmortalStarfishMinion_StrongGUI : ImmortalStarfishMinion_DurableGUI
    {

        public ImmortalStarfishMinion_StrongGUI()
            : base(typeof(ImmortalStarfishMinion_Strong))	
		{
		}



        public override string getInfo()
        {
            return "Upon dying divides herself into 5 " + makeInfoString("Child Starfishes") + " with 130 health and 1.3 movement speed.";
       }

        public override string getUpgradeInfo()
        {
            return "Now has " + makePositiveString("700") +  " health points.";
        }

    }
}
