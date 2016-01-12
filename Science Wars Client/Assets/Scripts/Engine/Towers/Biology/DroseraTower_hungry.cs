using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Biology
{
	public class DroseraTower_hungry : DroseraTower
	{
		public DroseraTower_hungry ()
		{
		}	

		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Hungry Drosera Tower";
		}
		
		#endregion
	}
}

