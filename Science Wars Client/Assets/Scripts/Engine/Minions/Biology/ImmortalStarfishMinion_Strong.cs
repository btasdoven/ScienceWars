using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
    class ImmortalStarfishMinion_Strong : ImmortalStarfishMinion_Durable
    {
        public ImmortalStarfishMinion_Strong()
            : base()
		{
            stats.healthTotal = stats.health = 700;
		}

		
		public override string getName ()
		{
			return "Strong Immortal Starfish";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

    }
}
