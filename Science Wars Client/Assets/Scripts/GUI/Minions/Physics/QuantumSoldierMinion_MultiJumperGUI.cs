using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Physics;

namespace Assets.Scripts.GUI.Minions
{
    class QuantumSoldierMinion_MultiJumperGUI : QuantumSoldierMinion_JumperGUI
    {
        public QuantumSoldierMinion_MultiJumperGUI()
            : base(typeof(QuantumSoldierMinion_MultiJumper))	
		{

		}

        public override string getInfo()
        {
            return "Multi Jumper Quantum Solider is able to jump 3 another minion in 50 range with himself.";
        }

        public override string getUpgradeInfo()
        {
            return "Now jumps " + makePositiveString("3") + " with himself.";
        }
    }
}
