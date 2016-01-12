using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Biology
{
	class OneToAllTower_toxic : OneToAllTower
	{
		public OneToAllTower_toxic()
		{
		}
		
		#region implemented abstract members of Tower
		
		public override string getName ()
		{
			return "Toxic One To All Tower";
		}
		
		#endregion
		
		
	}
}
