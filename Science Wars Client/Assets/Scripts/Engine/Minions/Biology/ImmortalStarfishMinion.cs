using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
	class ImmortalStarfishMinion : BiologyMinion
	{
		private static int cost = 2100;
		private static int income = 121;
		private static int killGold = 525;
		private static int healthCost = 5;
		
		
		public ImmortalStarfishMinion() : base()
		{
			// butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
			stats.healthTotal = stats.health = 650;
			stats.baseMovementSpeed = 0.7f;
			stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.PHYSICAL, .7f) });
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
			return "Immortal Starfish";
		}
		
		#region implemented abstract members of Minion
		
		protected override float getLocalHeadHeight ()
		{
			return 0.2f;
		}
		
		#endregion
	}
}
