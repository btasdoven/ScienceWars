using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
    class QuantumSoldierMinion_Fast : QuantumSoldierMinion
    {
        public QuantumSoldierMinion_Fast()
            : base()
		{
			
		}
		
		public override string getName ()
		{
			return "Fast Quantum Soldier";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
