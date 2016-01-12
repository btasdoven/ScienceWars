using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
	public class MutantEightLeggedSpawningMinion_WellFed : MutantEightLeggedSpawningMinion
	{
        public MutantEightLeggedSpawningMinion_WellFed()
            : base()
		{
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.FIRE, .9f), new DamageResistance(DamageType.PHYSICAL, .9f), new DamageResistance(DamageType.POISON, .9f) });
            stats.baseMovementSpeed = 1.1f;
		}

		public override string getName()
		{
			return "Well Fed Mutant Eight Legged Spawning";
		}
	}
}
