using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
	public class PhysicsStudentMinion : PhysicsMinion
	{
		private static int cost = 500;
		private static int income = 80;
		private static int killGold = 125;
		private static int healthCost = 1;
		
		public PhysicsStudentMinion() : base()
		{
			// butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
			stats.health = stats.healthTotal = 100;
			stats.baseMovementSpeed = 0.7f;
		}
		
		public override string getName ()
		{
			return "Physics Student";
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

        public override int getUpgradeCost()
        {
            return base.getUpgradeCost();
        }
		
		#region implemented abstract members of Minion
		
		protected override float getLocalHeadHeight ()
		{
			return 0.3f;
		}
		
		#endregion
	}
}
