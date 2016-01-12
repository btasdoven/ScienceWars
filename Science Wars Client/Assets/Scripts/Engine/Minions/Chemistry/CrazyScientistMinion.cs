using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Engine.Effects.MinionEffects;

namespace Assets.Scripts.Engine.Minions.Chemistry
{
    class CrazyScientistMinion : ChemistryMinion
    {
        private static int cost = 1350;
        private static int income = 108;
        private static int killGold = 337;
        private static int healthCost = 1;
		private static float effectRange = 0.7f;

        public CrazyScientistMinion() : base()
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.health = stats.healthTotal = 320;
            stats.baseMovementSpeed = 1.1f;
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.POISON, .8f) });
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
			return "Crazy Scientist";
		}

		#region implemented abstract members of Minion
		
		protected override float getLocalHeadHeight ()
		{
			return 0.3f;
		}
		
		#endregion
    }
}
