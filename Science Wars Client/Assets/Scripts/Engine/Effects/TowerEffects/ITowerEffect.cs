using Assets.Scripts.Engine.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Effects.TowerEffects
{
    public abstract class ITowerEffect
    {
		public float remainingTime;

		public abstract void step(Tower tower);
    }
}
