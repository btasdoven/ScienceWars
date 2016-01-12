using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Chemistry
{
    class ChemistryStudentMinion_Fast : ChemistryStudentMinion
    {

        public ChemistryStudentMinion_Fast()
            : base()
		{
            stats.baseMovementSpeed = 0.7f;
		}
		
		public override string getName ()
		{
			return "Fast Chemistry Student";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
