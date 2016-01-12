using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.GUI.Minions
{
    class BioLabStudentMinion_ShieldedGUI : BioLabStudentMinionGUI
    {

        public BioLabStudentMinion_ShieldedGUI()
            : base(typeof(BioLabStudentMinion_Shielded))	
		{
		}

        public override string getInfo()
        {
            return "This minion is very good aganist enemies with heavy " + makeInfoString("Physics")  + " damage.";
        }

        public override string getUpgradeInfo()
        {
            return "Gains " + makePositiveString("%40") + " " + makeInfoString("Physical") + " resistance.";
        }

    }
}
