using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
	public class FrankenScientistMinion : PhysicsMinion
	{
		private static int cost = 2700;
		private static int income = 130;
		private static int killGold = 250;
		private static int healthCost = 1;

        public FrankenScientistMinion()
            : base()
		{
			// butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
			stats.health = stats.healthTotal = 1100;
			stats.baseMovementSpeed = 0.65f;
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.PHYSICAL, .85f), new DamageResistance(DamageType.POISON, .85f) });
		}

	    public override string getName ()
		{
			return "Frankenscientist";
		}

        public virtual ScrapGolemMinion createScrapGolem()
        {
            return new ScrapGolemMinion();
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
