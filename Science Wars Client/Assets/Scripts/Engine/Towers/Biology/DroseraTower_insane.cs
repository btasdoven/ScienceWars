using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Towers.Biology
{
		public class DroseraTower_insane : DroseraTower_crazy
		{
				public DroseraTower_insane ()
				{
				}

				#region implemented abstract members of Tower
				
				public override string getName ()
				{
					return "Insane Drosera Tower";
				}
				
				#endregion
		}
}

