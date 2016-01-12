using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;

namespace Science_Wars_Server.Minions.Biology
{
    class ImmortalStarfishMinion_Durable : ImmortalStarfishMinion
    {
        public ImmortalStarfishMinion_Durable(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.PHYSICAL, .7f), new DamageResistance(DamageType.POISON, .7f) });
        }

        public override int getUpgradeCost()
        {
            return 0;
        }
    }
}
