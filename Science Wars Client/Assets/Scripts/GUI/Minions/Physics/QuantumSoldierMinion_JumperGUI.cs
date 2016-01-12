using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Physics;

namespace Assets.Scripts.GUI.Minions
{
    class QuantumSoldierMinion_JumperGUI : QuantumSoldierMinionGUI
    {
         public QuantumSoldierMinion_JumperGUI()
            : base(typeof(QuantumSoldierMinion_Jumper))	
		{

		}

         public QuantumSoldierMinion_JumperGUI(Type minionType)
            : base(minionType)
        {

        }

        public override string getInfo()
        {
            return "Jumper Quantum Solider is able to jump another minion in 50 range with himself.";
        }

        public override string getUpgradeInfo()
        {
            return "Jumper Quantum Solider is able to jump another minion in 50 range with himself.";
        }
    }
}
