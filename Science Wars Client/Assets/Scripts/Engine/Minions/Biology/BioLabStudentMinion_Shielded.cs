using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.GameUtilities;

namespace Assets.Scripts.Engine.Minions.Biology
{
    class BioLabStudentMinion_Shielded : BioLabStudentMinion
    {

        public BioLabStudentMinion_Shielded()
            : base()
		{
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.FIRE, .9f), new DamageResistance(DamageType.POISON, .9f), new DamageResistance(DamageType.PHYSICAL, .6f) });
		}
		
		public override string getName ()
		{
			return "Shielded Biology Lab Student";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

    }
}
