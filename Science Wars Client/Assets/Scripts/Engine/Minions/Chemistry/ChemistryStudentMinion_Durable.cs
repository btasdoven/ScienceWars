using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.GameUtilities;

namespace Assets.Scripts.Engine.Minions.Chemistry
{
    class ChemistryStudentMinion_Durable : ChemistryStudentMinion
    {

        public ChemistryStudentMinion_Durable()
            : base()
		{
			stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.FIRE, .9f),new DamageResistance(DamageType.PHYSICAL, .9f),new DamageResistance(DamageType.POISON, .9f) });
		}
		
		public override string getName ()
		{
			return "Durable Chemistry Student";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
