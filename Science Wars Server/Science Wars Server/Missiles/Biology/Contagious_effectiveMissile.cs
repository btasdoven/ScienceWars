using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Missiles.Biology
{
    class Contagious_effectiveMissile : ContagiousMissile
    {
        public Contagious_effectiveMissile(Tower ownerTower, Minion targetMinion)
            :  base(ownerTower, targetMinion)
        {
            movementSpeed = 3.0f;
        }

        protected override MinionEffect getMinionEffect(Player p)
        {
            return new ContagiousEffect_effective(p);
        }
    }
}
