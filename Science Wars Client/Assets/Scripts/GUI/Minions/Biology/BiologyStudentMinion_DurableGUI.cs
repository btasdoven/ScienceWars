using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.GUI.Minions
{
    class BiologyStudentMinion_DurableGUI : BiologyStudentMinionGUI
    {
        public BiologyStudentMinion_DurableGUI()
            : base(typeof(BiologyStudentMinion_Durable))	
		{
		}

        public override string getInfo()
        {
            return "Durable Biology Student is a more durable version of Biology Student.";
        }

        public override string getUpgradeInfo()
        {
            return "Health is increased to " + makePositiveString("120")  + ".";
        }
    }
}
