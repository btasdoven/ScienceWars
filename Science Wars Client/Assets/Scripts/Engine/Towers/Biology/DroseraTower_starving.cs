using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Biology
{
		public class DroseraTower_starving : DroseraTower_hungry
		{
				public DroseraTower_starving ()
				{
				}

		
				#region implemented abstract members of Tower
				
				public override string getName ()
				{
					return "Starving Drosera Tower";
				}
				
				#endregion
		}
}

