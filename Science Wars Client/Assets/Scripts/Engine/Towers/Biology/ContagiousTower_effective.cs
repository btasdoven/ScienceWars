using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Biology
{
	public class ContagiousTower_effective : ContagiousTower	{
		public ContagiousTower_effective ()
		{
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Effective Contagious Tower";
		}
		
		#endregion
	}
}

