using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.GUI.Minions
{
    class BioLabStudentMinion_DangerousGUI : BioLabStudentMinionGUI
    {

        public BioLabStudentMinion_DangerousGUI()
            : base(typeof(BioLabStudentMinion_Dangerous))	
		{
		}

        public override string getInfo()
        {
            return "This minion deals 2 health damage to a player if passes a board without dying.";
        }

        public override string getUpgradeInfo()
        {
            return "Now deals " + makePositiveString("2") +  " health damage to a player upon passing a board." ;
        }

    }
}
