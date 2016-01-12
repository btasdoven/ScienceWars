using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Physics;

namespace Assets.Scripts.GUI.Minions
{
    class PhysicsMScStudentMinion_CheaperGUI : PhysicsMScStudentMinionGUI
    {

        public PhysicsMScStudentMinion_CheaperGUI()
            : base(typeof(PhysicsMScStudentMinion_Cheaper))	
		{
		}

        public PhysicsMScStudentMinion_CheaperGUI(Type minionType)    //upgradeler icin
            : base(minionType)
        {
        }

        public override string getInfo()
        {
            return "Cheap Physics MSc Student is the cheap version of Physics MSc Student.";
        }

        public override string getUpgradeInfo()
        {
            return "Cost is reduced to" + makePositiveString("700") + ".";
        }
    }
}
