    using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Physics
{
	class LaserTower_Triplet : LaserTower_Twin
	{
        public LaserTower_Triplet()
		{
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Triplet Laser Tower";
		}
		
		#endregion
		

	}
}
