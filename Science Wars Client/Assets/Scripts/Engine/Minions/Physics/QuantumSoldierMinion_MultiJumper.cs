using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
    class QuantumSoldierMinion_MultiJumper : QuantumSoldierMinion_Jumper
    {
        public QuantumSoldierMinion_MultiJumper()
            : base()
		{
			
		}
		
		public override string getName ()
		{
			return "Multi Jumper Quantum Soldier";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
