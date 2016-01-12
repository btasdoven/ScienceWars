using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Physics;

namespace Assets.Scripts.GUI.Minions
{
    class QuantumSoldierMinion_FastGUI : QuantumSoldierMinionGUI
    {

         public QuantumSoldierMinion_FastGUI()
            : base(typeof(QuantumSoldierMinion_Fast))	
		{

		}

         public QuantumSoldierMinion_FastGUI(Type minionType)
            : base(minionType)
        {

        }

        public override string getInfo()
        {
            return "Fast Quantum Solider is able to run 2 times faster upon a jump for 2 seconds.";
        }

        public override string getUpgradeInfo()
        {
            return "Fast Quantum Solider runs "+  makePositiveString("2") + " times faster when he jumps for 2 seconds.";
        }
    }
}
