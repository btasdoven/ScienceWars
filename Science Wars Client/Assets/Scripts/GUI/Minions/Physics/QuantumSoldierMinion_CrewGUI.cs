using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Physics;

namespace Assets.Scripts.GUI.Minions
{
    class QuantumSoldierMinion_CrewGUI : QuantumSoldierMinion_FastGUI
    {
         public QuantumSoldierMinion_CrewGUI()
            : base(typeof(QuantumSoldierMinion_Crew))	
		{

		}

        public override string getInfo()
        {
            return "Fast Crew Quantum Solider is able to run 2 times faster upon a jump for 2 seconds and can apply this effect to two minions in 50 range.";
        }

        public override string getUpgradeInfo()
        {
            return "Fast Crew Quantum Solider runs "+  makePositiveString("2") + " times faster when he jumps for 2 seconds and applies this effect to two other minions in 50 range.";
        }
    }
}
