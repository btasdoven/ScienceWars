using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Physics
{
	class LaserTower_Quintuplet : LaserTower_Quadruplet
	{
        public LaserTower_Quintuplet()
		{
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Quintuplet Laser Tower";
		}
		
		public override float getAttackCooldown()
		{
			return ATTACK_COOLDOWN;
		}

		#endregion
		

	}
}
