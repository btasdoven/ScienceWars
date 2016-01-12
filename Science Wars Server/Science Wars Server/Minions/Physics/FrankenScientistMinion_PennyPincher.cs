using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Strategies.TargetStrategies;

namespace Science_Wars_Server.Minions.Physics
{
    class FrankenScientistMinion_PennyPincher : FrankenScientistMinion
    {
        private const int _requiredDeadMinionCount = 4; // kac minion toplayinca yeni minion cikaracagiz?

        protected override int REQUIRED_DEAD_MINION_COUNT { get { return _requiredDeadMinionCount; } } 

        public FrankenScientistMinion_PennyPincher(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {            
        }

    }
}
