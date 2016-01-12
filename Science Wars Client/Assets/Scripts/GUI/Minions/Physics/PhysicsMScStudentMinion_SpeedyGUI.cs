using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Physics;

namespace Assets.Scripts.GUI.Minions
{
    class PhysicsMScStudentMinion_SpeedyGUI : PhysicsMScStudentMinionGUI
    {
        public PhysicsMScStudentMinion_SpeedyGUI()
            : base(typeof(PhysicsMScStudentMinion_Speedy))	
		{
		}

        public PhysicsMScStudentMinion_SpeedyGUI(Type minionType)    //upgradeler icin
            : base(minionType)
        {
        }

        public override string getInfo()
        {
            return "Speedy  Physics MSc Student is a faster version of Physics MSc Student.";
        }

        public override string getUpgradeInfo()
        {
            return "Base movement speed is increased to " + makePositiveString("1.45")  + ".";
        }
    }
}
