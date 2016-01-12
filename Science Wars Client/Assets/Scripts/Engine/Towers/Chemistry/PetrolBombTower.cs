using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Chemistry
{
	class PetrolBombTower : ChemistryTower
	{
		private static int cost = 11100;
		
		private float nextAttackTime = 0;
		private float ATTACK_COOLDOWN = 5.5f;
		
		public PetrolBombTower()
		{
			// base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
			stats.baseRange = 2.5f;
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Petrol Bomb Tower";
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
