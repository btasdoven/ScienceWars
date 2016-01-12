using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Biology
{
	public class DroseraTower : BiologyTower
	{
		private static int cost = 13500;
		
		private float nextAttackTime = 0;  // sadece kullaniciyi bilgilendirme amaciyla tutuyoruz burada, missile ateslemekte kullanilmiyor.
		
		public DroseraTower()
		{
			// base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
			stats.baseRange = 0.8f;
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
			return "Drosera Tower";
		}
		
		public override float getAttackCooldown()
		{
			//this tower doesn't have a cooldown
			return -1;
		}
		
		public override float getRange()
		{
			return stats.baseRange;
		}
		
		#region implemented abstract members of Tower
		
		protected override float getLocalMissileCreateHeight ()
		{
			return 0.2f;
		}
		
		#endregion
		
	}
}
