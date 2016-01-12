using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions.Biology;

namespace Assets.Scripts.Engine.Minions.Biology
{
    public class MutantEightLeggedMinion : BiologyMinion
	{
		private static int cost = 2700;
		private static int income = 130;
		private static int killGold = 250;
		private static int healthCost = 1;

        public MutantEightLeggedMinion()
            : base()
		{
			// butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
			stats.health = stats.healthTotal = 1100;
			stats.baseMovementSpeed = 0.9f;
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.PHYSICAL, .75f), new DamageResistance(DamageType.FIRE, .75f), new DamageResistance(DamageType.POISON, .75f) });
		}

	    public override string getName ()
		{
			return "Mutant Eight Legged";
		}

        public virtual MutantEightLeggedSpawningMinion createSpawning()
        {
            return new MutantEightLeggedSpawningMinion();
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
		
		#region implemented abstract members of Minion
		
		protected override float getLocalHeadHeight ()
		{
			return 0.3f;
		}
		
		#endregion
	}
}
