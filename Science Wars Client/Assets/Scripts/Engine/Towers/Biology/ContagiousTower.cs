using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Biology
{
	public class ContagiousTower : BiologyTower
	{
		private static int cost = 3500;
		
		private float nextAttackTime = 0;  // sadece kullaniciyi bilgilendirme amaciyla tutuyoruz burada, missile ateslemekte kullanilmiyor.
		private float ATTACK_COOLDOWN = 1.5f;   // sadece kullaniciyi bilgilendirme amaciyla tutuyoruz burada, missile ateslemekte kullanilmiyor.
		
		public ContagiousTower()
		{
			// base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
			stats.baseRange = 0.9f;
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
			return "Contagious Tower";
		}
		
		public override float getRange()
		{
			return stats.baseRange;
		}
		
		public override float getAttackCooldown()
		{
			return ATTACK_COOLDOWN;
		}
		
		#region implemented abstract members of Tower
		
		protected override float getLocalMissileCreateHeight ()
		{
			return 0.6f;
		}
		
		#endregion
		
	}
}
