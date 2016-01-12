using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Biology
{
	class SeedTower : BiologyTower
	{
		private static int cost = 1000;
		private static int MAX_STACK_SIZE = 5;
		private static float SEED_RELOAD_TIME = 10f;
		private static float SEED_CREATION_DELAY = 0.2f;
		
		public int seedCountInStack = 0;
		private float nextReloadTime = 0;
		private float nextSeedCreateTime = 0;
		
		public SeedTower()
		{
			// base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
			stats.baseRange = 1.1f;
		}
		
		public override void step()
		{
		}


		public override int getCost()
		{
			return cost;
		}
		
		public override string getName ()
		{
			return "Seed Tower";
		}
		
		
		
		public override float getAttackCooldown()
		{
			return SEED_RELOAD_TIME;
		}
		
		public override float getRange()
		{
			return stats.baseRange;
		}
		
		#region implemented abstract members of Tower
		
		protected override float getLocalMissileCreateHeight ()
		{
			return 0.6f;
		}
		
		#endregion
		
	}
}
