using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Towers.Chemistry
{
    class TrypanophobiaTower_Monstrous : TrypanophobiaTower_Scary
	{
		private static int cost = 4500;
		
		private float nextAttackTime = 0;
		private float ATTACK_COOLDOWN = 2.0f;

        public TrypanophobiaTower_Monstrous()
		{
			// base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
			stats.baseRange = 1.2f;
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
            return "Monstrous Trypanophobia Tower";
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
