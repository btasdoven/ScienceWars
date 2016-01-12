using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
	class DollyMinion : BiologyMinion
	{
		private static int cost = 1100;
		private static int income = 102;
		private static int killGold = 225;
		private static int healthCost = 1;
		private static float effectCooldownTime = 5.0f;
		
		public DollyMinion() : base()
		{
			// butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
			stats.healthTotal = stats.health = 220;
			stats.baseMovementSpeed = 0.8f;
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
			return "Dolly";
		}

		#region implemented abstract members of Minion
		
		protected override float getLocalHeadHeight ()
		{
			return 0.1f;
		}
		
		#endregion
	}
}
