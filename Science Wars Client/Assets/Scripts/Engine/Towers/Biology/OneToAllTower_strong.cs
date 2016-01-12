using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Biology
{
	class OneToAllTower_strong : OneToAllTower
	{
		public OneToAllTower_strong()
		{
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Strong One To All Tower";
		}
		
		#endregion
		
		
	}
}
