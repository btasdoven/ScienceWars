using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Physics
{
	class TeslaTower : PhysicsTower
	{
		private static int cost = 12000;
		
		private float nextAttackTime = 0;  // sadece kullaniciyi bilgilendirme amaciyla tutuyoruz burada, missile ateslemekte kullanilmiyor.
		private float ATTACK_COOLDOWN = 0.6f;   // sadece kullaniciyi bilgilendirme amaciyla tutuyoruz burada, missile ateslemekte kullanilmiyor.
		
		public TeslaTower()
		{
			// base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
			stats.baseRange = 1.5f;
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
			return "Tesla Tower";
		}
		
		public override float getAttackCooldown()
		{
			return ATTACK_COOLDOWN;
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
