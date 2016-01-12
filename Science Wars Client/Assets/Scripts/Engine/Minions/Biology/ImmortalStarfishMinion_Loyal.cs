using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
    class ImmortalStarfishMinion_Loyal : ImmortalStarfishMinion
    {
        public ImmortalStarfishMinion_Loyal()
            : base()
		{
            
		}

		
		public override string getName ()
		{
			return "Loyal Immortal Starfish";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
