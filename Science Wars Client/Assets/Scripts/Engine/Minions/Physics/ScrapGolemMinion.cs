using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
	public class ScrapGolemMinion : PhysicsMinion
	{
		private static int cost = 0;
		private static int income = 0;
		private static int killGold = 250;
		private static int healthCost = 1;

        public ScrapGolemMinion()
            : base()
		{
			// butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
			stats.health = stats.healthTotal = 2000;
			stats.baseMovementSpeed = 0.45f;
            stats.setBaseResistances(new List<DamageResistance>(){
                new DamageResistance(DamageType.PHYSICAL,0.6f),
                new DamageResistance(DamageType.FIRE,0.6f),
                new DamageResistance(DamageType.POISON,0.6f)});
		}
		
		public override string getName ()
		{
			return "Scrap Golem";
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
