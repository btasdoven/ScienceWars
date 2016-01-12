using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Engine.Effects.MinionEffects;

namespace Assets.Scripts.Engine.Minions.Chemistry
{
	class ChemLabStudentMinion : ChemistryMinion
	{
		private static int cost = 800;
		private static int income = 93;
		private static int killGold = 200;
		private static int healthCost = 1;
		
		public ChemLabStudentMinion() : base()
		{
			// butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
			stats.health = stats.healthTotal = 160;
			stats.baseMovementSpeed = 0.8f;
			stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.FIRE, .8f) });
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
			return "Chem Lab Student";
		}
		
		#region implemented abstract members of Minion
		
		protected override float getLocalHeadHeight ()
		{
			return 0.3f;
		}
		
		#endregion
	}
}
