using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
    class QuantumSoldierMinion_Crew : QuantumSoldierMinion_Fast
    {
        public QuantumSoldierMinion_Crew()
            : base()
		{
			
		}
		
		public override string getName ()
		{
			return "Fast Crew Quantum Soldier";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
