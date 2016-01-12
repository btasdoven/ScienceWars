using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions.Biology
{
    class DollyMinion_Lesscd : DollyMinion
    {

        private const float _default_effect_cooldown_time = 4.5f;
        protected override float DEFAULT_EFFECT_COOLDOWN_TIME
        {
            get
            {
                return _default_effect_cooldown_time;
            }
        }

        public DollyMinion_Lesscd(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

    }
}
