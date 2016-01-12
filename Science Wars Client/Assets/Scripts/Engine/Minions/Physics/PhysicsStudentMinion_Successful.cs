using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
	class PhysicsStudentMinion_Successful : PhysicsStudentMinion
	{
		public PhysicsStudentMinion_Successful() : base()
		{
			stats.health = stats.healthTotal = 120;
		}
		
		public override string getName ()
		{
			return "Successful Physics Student";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
	}
}
