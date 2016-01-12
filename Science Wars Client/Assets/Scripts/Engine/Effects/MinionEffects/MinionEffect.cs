using Assets.Scripts.Engine.Minions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Effects.MinionEffects
{
    public abstract class MinionEffect
    {
		public float remainingTime;

		public abstract void step(Minion minion);
    }
}
