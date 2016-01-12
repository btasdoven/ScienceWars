using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Physics
{
	class BallistaTower_lavaBolt : BallistaTower_fireBolt
	{
		public BallistaTower_lavaBolt()
		{
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Lava Bolt Ballista Tower";
		}
		
		#endregion
		
		
	}
}
