using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
    class ImmortalStarfishMinion_FastLoyal : ImmortalStarfishMinion_Loyal
    {
        public ImmortalStarfishMinion_FastLoyal()
            : base()
		{
            
		}
	
		public override string getName ()
		{
			return "Fast Loyal Immortal Starfish";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
