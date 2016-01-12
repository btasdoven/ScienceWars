using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Physics
{
	public class LaserTower : PhysicsTower
	{
		protected static int cost = 12000;
		
		protected float ATTACK_COOLDOWN = 0.5f;

        public LaserTower()
		{
			// base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
			stats.baseRange = 1.1f;
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Laser Tower";
		}
		
		public override float getAttackCooldown()
		{
			return ATTACK_COOLDOWN;
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
			return 0.4f;
		}

		#endregion
	}
}
