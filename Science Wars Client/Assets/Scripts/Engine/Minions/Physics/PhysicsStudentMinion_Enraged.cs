using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
    class PhysicsStudentMinion_Enraged : PhysicsStudentMinion_Successful
	{
		public PhysicsStudentMinion_Enraged() : base()
		{
			stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.FIRE, .9f),new DamageResistance(DamageType.PHYSICAL, .9f),new DamageResistance(DamageType.POISON, .9f) });
		}
		
		public override string getName ()
		{
			return "Enraged Physics Student";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
	}
}
