using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Physics
{
	public class ScrapGolemMinion_Overheat : ScrapGolemMinion
	{
        public ScrapGolemMinion_Overheat()
            : base()
		{
			stats.baseMovementSpeed = 0.60f;
		}
		
		public override string getName ()
		{
			return "Over-Heated Scrap Golem";
		}
	}
}
