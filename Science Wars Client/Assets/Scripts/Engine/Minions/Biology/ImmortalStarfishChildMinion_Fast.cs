using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions.Biology
{
    class ImmortalStarfishChildMinion_Fast : ImmortalStarfishChildMinion_Durable
    {

        public ImmortalStarfishChildMinion_Fast()
            : base()
		{
            stats.baseMovementSpeed = 1.4f;
		}
		
		public override string getName ()
		{
			return "Fast Durable Child Starfish";
		}

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

    }
}
