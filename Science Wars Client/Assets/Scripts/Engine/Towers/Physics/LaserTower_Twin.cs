using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Physics
{
	class LaserTower_Twin : LaserTower
	{
        public LaserTower_Twin()
		{
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Twin Laser Tower";
		}
		
		#endregion
		

	}
}
