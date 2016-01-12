using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Minions.Physics
{
    class PhysicsStudentMinion_Enraged : PhysicsStudentMinion_Successful
    {
        public PhysicsStudentMinion_Enraged(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.FIRE, .9f), new DamageResistance(DamageType.PHYSICAL, .9f), new DamageResistance(DamageType.POISON, .9f) });
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
