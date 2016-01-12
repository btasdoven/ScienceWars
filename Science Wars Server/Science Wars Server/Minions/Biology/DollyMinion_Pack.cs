using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions.Biology
{
    class DollyMinion_Pack : DollyMinion
    {
        private const int _max_copies = 2;
        protected override int MAX_COPIES { get { return _max_copies; } }

        public DollyMinion_Pack(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
