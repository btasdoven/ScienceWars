using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Engine.Effects.MinionEffects;

namespace Assets.Scripts.Engine.Minions.Chemistry
{
	class FirstAidTentMinion : ChemistryMinion
	{
		private static int cost = 4700;
		private static int income = 149;
		private static int killGold = 1175;
		private static int healthCost = 4;
		
		public FirstAidTentMinion() : base()
		{
			// butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
			stats.healthTotal = stats.health = 1020;
			stats.baseMovementSpeed = 0.45f;
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
			return "First Aid Tent Minion";
		}
		
		#region implemented abstract members of Minion
		
		protected override float getLocalHeadHeight ()
		{
			return 0.3f;
		}
		
		#endregion
	}
}
