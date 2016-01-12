using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
    class PhysicsMScStudentMinion_Cheaper : PhysicsMScStudentMinion
    {

        public PhysicsMScStudentMinion_Cheaper()
            : base()
		{
            
		}
		
		public override string getName ()
		{
			return "Cheap Physics MSc Student";
		}

        public override int getCost()
        {
            return 700;
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

    }
}
