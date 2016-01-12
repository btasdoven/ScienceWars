using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
    class ImmortalStarfishChildMinion_Durable : ImmortalStarfishChildMinion
    {
        public ImmortalStarfishChildMinion_Durable()
            : base()
		{
            stats.health = stats.healthTotal = 150;
		}
		
		public override string getName ()
		{
			return "Durable Child Starfish";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
