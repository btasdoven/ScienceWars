using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
    class PhysicsMScStudentMinion_Speedy : PhysicsMScStudentMinion
    {

        public PhysicsMScStudentMinion_Speedy()
            : base()
		{
            stats.baseMovementSpeed = 1.45f;
		}
		
		public override string getName ()
		{
			return "Speedy Physics MSc Student";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

    }
}
