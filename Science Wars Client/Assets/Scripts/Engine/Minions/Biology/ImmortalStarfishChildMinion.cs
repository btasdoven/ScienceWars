using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
	class ImmortalStarfishChildMinion : BiologyMinion
	{
		private static int cost = 0;
		private static int income = 0;
		private static int killGold = 0;
		private static int healthCost = 1;
		
		
		public ImmortalStarfishChildMinion() : base()
		{
			// butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
			stats.healthTotal = stats.health = 130;
			stats.baseMovementSpeed = 1.3f;
			stats.setBaseResistances(new List<DamageResistance>() {});
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
			return "Child Starfish";
		}
		
		#region implemented abstract members of Minion
		
		protected override float getLocalHeadHeight ()
		{
			return 0.15f;
		}
		
		#endregion
	}
}
