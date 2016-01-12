using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.GUI.Minions
{
    class BiologyStudentMinion_FasterGUI : BiologyStudentMinionGUI
    {

        public BiologyStudentMinion_FasterGUI()
            : base(typeof(BiologyStudentMinion_Faster))	
		{
		}

        public override string getInfo()
        {
            return "Speedy Biology Student is a faster version of Biology Student.";
        }

        public override string getUpgradeInfo()
        {
            return "Base movement speed is increased to " + makePositiveString("0.7")  + ".";
        }

    }
}
