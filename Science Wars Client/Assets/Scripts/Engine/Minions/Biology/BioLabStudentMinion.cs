using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
	class BioLabStudentMinion : BiologyMinion
	{
		private static int cost = 850;
		private static int income = 95;
		private static int killGold = 212;
		private static int healthCost = 1;
		
		public BioLabStudentMinion() : base()
		{
			// butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
			stats.health = stats.healthTotal = 90;
			stats.baseMovementSpeed = 0.75f;
			stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.FIRE, .9f) });
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
			return "Biology Lab Student";
		}
		
		#region implemented abstract members of Minion
		
		protected override float getLocalHeadHeight ()
		{
			return 0.1f;
		}
		
		#endregion
	}
}
