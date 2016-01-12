using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
    class QuantumSoldierMinion_Jumper : QuantumSoldierMinion
    {

        public QuantumSoldierMinion_Jumper()
            : base()
		{
			
		}
		
		public override string getName ()
		{
			return "Jumper Quantum Soldier";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
