using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Minions;

namespace Science_Wars_Server.Effects.MinionEffects
{
    public abstract class MinionEffect
    {
        public float remainingTime;
        public Player ownerPlayer;
        
        public abstract bool isStackable();

        public abstract void step(Minion minion);
    }
}
