using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
	class QuantumSoldierMinion : PhysicsMinion
	{
        private static int cost = 2000;
        private static int income = 120;
        private static int killGold = 500;
        private static int healthCost = 1;

        private static float NEXT_TELEPORT_COOLDOWN_DEFAULT = 12.0f;
        private static float TELEPORT_DISTANCE_DEFAULT = 1.3f;

        private float nextTeleportTime;

        public QuantumSoldierMinion()
            : base()
		{
			// butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
			stats.health = stats.healthTotal = 480;
			stats.baseMovementSpeed = 1f;
			stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.POISON, .8f) });
		}

		public override string getName ()
		{
			return "Quantum Soldier";
		}
        
        public void teleport()
        {
            nextTeleportTime = NEXT_TELEPORT_COOLDOWN_DEFAULT;
            moveCustomDistance(TELEPORT_DISTANCE_DEFAULT);            
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

        public virtual void onJumpEnded()
        {

        }

        public virtual void onJumpStarted()
        {

        }
		#region implemented abstract members of Minion
		
		protected override float getLocalHeadHeight ()
		{
			return 0.3f;
		}
		
		#endregion
	}
}
