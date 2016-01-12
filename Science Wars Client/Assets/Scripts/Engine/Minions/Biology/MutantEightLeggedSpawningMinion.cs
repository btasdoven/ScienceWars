using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
	public class MutantEightLeggedSpawningMinion : BiologyMinion
	{
        private static int cost = 0;
        private static int income = 0;
        private static int killGold = 10;
        private static int healthCost = 0;

        public MutantEightLeggedSpawningMinion()
            : base()
		{
			stats.health = stats.healthTotal = 220;
			stats.baseMovementSpeed = 0.9f;
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.FIRE, 1f), new DamageResistance(DamageType.PHYSICAL, 1f), new DamageResistance(DamageType.POISON, 1f) });
		}
		
		public override int getCost()
		{
			return cost;
		}
		
		public override int getIncome()
		{
			return income;
		}
		
		public override int getKillGold()
		{
			return killGold;
		}
		
		public override int getHealthCost()
		{
			return healthCost;
		}
		
		public override string getName()
		{
			return "Mutant Eight Legged Spawning";
		}
		
		#region implemented abstract members of Minion
		
		protected override float getLocalHeadHeight ()
		{
			return 0.1f;
		}
		
		#endregion
	}
}
