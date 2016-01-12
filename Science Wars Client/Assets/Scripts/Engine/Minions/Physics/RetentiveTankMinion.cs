using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
	class RetentiveTankMinion : PhysicsMinion
	{
		private static int cost = 4500;
		private static int income = 147;
		private static int killGold = 1125;
		private static int healthCost = 5;
		
		private static float NEXT_DISABLE_COOLDOWN_DEFAULT = 9.0f;
		private static float DISABLE_DISTANCE_DEFAULT = 1.5f;
		
		private float nextDisableTime;
		
		public RetentiveTankMinion()
			: base()
		{
			// butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
			stats.health = stats.healthTotal = 920;
			stats.baseMovementSpeed = 0.5f;
			stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.POISON, .7f),
																	new DamageResistance(DamageType.FIRE, .7f)});
		}
		
		public override string getName ()
		{
			return "Retentive Tank";
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
