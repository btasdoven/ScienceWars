using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Physics
{
	class NailTrapTower : PhysicsTower
	{
		private static int cost = 4000;
		
		private float nextAttackTime = 0;
		private float ATTACK_COOLDOWN = 4.0f; 
		
		public NailTrapTower()
		{
			// base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
			stats.baseRange = 2.0f;
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Nail Trap Tower";
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
			return 0.6f;
		}
		
		#endregion
	}
}
