using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Towers.Physics;

namespace Assets.Scripts.Engine.Towers.Physics
{
	class NailTrapTower_MoreSlow : NailTrapTower
	{
		private static int cost = 4000;
		
		private float nextAttackTime = 0;
		private float ATTACK_COOLDOWN = 4.0f; 
		
		public NailTrapTower_MoreSlow()
		{
			// base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
			stats.baseRange = 2.0f;
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Nail Trap Tower More Slow";
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
