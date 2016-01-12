using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
    class DollyMinion_Pack : DollyMinion
    {

        public DollyMinion_Pack()
            : base()
		{
            
		}
		
		public override string getName ()
		{
			return "Pack Dolly";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

    }
}
