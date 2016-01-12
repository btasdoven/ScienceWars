using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Biology
{
	public class ContagiousTower_extra : ContagiousTower	{
		public ContagiousTower_extra ()
		{
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Extra Contagious Tower";
		}
		
		#endregion
	}
}

