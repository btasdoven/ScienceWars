using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Physics
{
	class CatapultTower : BallistaTower //PhysicsTower
	{
		private static int cost = 150;
		
		private float nextAttackTime = 0;
		private float ATTACK_COOLDOWN = 3.0f; 
		
		public CatapultTower()
		{
			// base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
			stats.baseRange = 6.8f;
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Catapult Tower";
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
