using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Physics
{
	class BlackHoleTower : PhysicsTower
	{
		private static int cost = 4000;

        private float nextAttackTime = 0;
        private static float TELEPORT_COOLDOWN_DEFAULT = 4.0f;
        private static float TELEPORT_DISTANCE_DEFAULT = 2f;
        private static float TELEPORT_DIAMETER_DEFAULT = 0.5f;
		
		public BlackHoleTower()
		{
			// base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
			stats.baseRange = 2f;
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Black Hole Tower";
		}
		
		public override float getAttackCooldown()
		{
			return TELEPORT_COOLDOWN_DEFAULT;
		}
		
		public override float getRange()
		{
			return stats.baseRange;
		}

		#endregion
		
		public override void step()
		{			
		}
		
		public override int getCost()
		{
			return cost;
		}
		#region implemented abstract members of Tower
		
		protected override float getLocalMissileCreateHeight ()
		{
			return 0.6f;
		}
		
		#endregion
	}
}
