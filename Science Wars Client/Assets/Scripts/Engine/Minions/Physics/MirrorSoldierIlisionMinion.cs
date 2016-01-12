using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
	class MirrorSoldierIlisionMinion : PhysicsMinion
	{
		private static int cost = 0;
		private static int upgradeCost = 0;
		private static int income = 0;
		private static int killGold = 0;
		private static int healthCost = 0;
		private static float effectCooldownTime;
		
		public  MirrorSoldierIlisionMinion() : base()
		{
			// butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
			stats.health = stats.healthTotal = 320;
			stats.baseMovementSpeed = 1.1f;
		}

	    public override string getName ()
		{
			return "Mirror Soldier Ilision";
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
