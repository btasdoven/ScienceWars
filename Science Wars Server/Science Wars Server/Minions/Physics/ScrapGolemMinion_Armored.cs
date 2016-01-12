using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Minions.Physics
{
    class ScrapGolemMinion_Armored : ScrapGolemMinion_Overheat
    {
        public ScrapGolemMinion_Armored(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            stats.setBaseResistances(new List<DamageResistance>(){
                new DamageResistance(DamageType.PHYSICAL,0.4f),
                new DamageResistance(DamageType.FIRE,0.4f),
                new DamageResistance(DamageType.POISON,0.4f)});
        }
    }
}
