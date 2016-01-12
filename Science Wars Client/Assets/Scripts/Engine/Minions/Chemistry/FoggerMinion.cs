using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Engine.Effects.MinionEffects;

namespace Assets.Scripts.Engine.Minions.Chemistry
{
	class FoggerMinion : ChemistryMinion
	{
        private static int cost = 2250;
        private static int income = 124;
        private static int killGold = 562;
        private static int healthCost = 1;
		
		public FoggerMinion() : base()
		{
			// butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.health = stats.healthTotal = 560;
            stats.baseMovementSpeed = 0.6f;
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
			return "Fogger";
		}
		
		#region implemented abstract members of Minion
		
		protected override float getLocalHeadHeight ()
		{
			return 0.3f;
		}
		
		#endregion
	}
}
