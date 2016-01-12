using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Minions.Biology
{
    class BioLabStudentMinion_Shielded : BioLabStudentMinion
    {

        public BioLabStudentMinion_Shielded(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.FIRE, .9f), new DamageResistance(DamageType.POISON, .9f), new DamageResistance(DamageType.PHYSICAL, .6f) });
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

    }
}
