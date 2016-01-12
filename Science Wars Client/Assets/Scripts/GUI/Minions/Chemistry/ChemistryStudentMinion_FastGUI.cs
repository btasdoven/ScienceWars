using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Chemistry;

namespace Assets.Scripts.GUI.Minions
{
    class ChemistryStudentMinion_FastGUI : ChemistryStudentMinionGUI
    {

        public ChemistryStudentMinion_FastGUI()
            : base(typeof(ChemistryStudentMinion_Fast))	
		{
		}


        public override string getInfo()
        {
            return makeInfoString("Fast Chemistry Student") + " is the fast version of " + makeInfoString("Chemistry Student") + ".";
        }

        public override string getUpgradeInfo()
        {
            return "Base movement speed is increased to " + makePositiveString("0.7")  + ".";
        }
    }
}
