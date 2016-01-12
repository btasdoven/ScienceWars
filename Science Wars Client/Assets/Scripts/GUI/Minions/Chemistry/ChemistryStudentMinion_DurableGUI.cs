using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Chemistry;

namespace Assets.Scripts.GUI.Minions
{
    class ChemistryStudentMinion_DurableGUI : ChemistryStudentMinionGUI
    {

        public ChemistryStudentMinion_DurableGUI()
            : base(typeof(ChemistryStudentMinion_Durable))	
		{
		}


        public override string getInfo()
        {
            return makeInfoString("Durable Chemistry Student") + " is the durable version of " + makeInfoString("Chemistry Student") + ".";
        }

        public override string getUpgradeInfo()
        {
            return "Gains " + makePositiveString("%10") + " resistance aganist all damage types.";
        }

    }
}
