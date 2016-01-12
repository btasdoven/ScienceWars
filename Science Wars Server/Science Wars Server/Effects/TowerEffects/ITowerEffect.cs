using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Towers;

namespace Science_Wars_Server.Effects.TowerEffects
{
    public abstract class ITowerEffect
    {
        public float remainingTime;

        public abstract void step(Tower tower);
    }
}
