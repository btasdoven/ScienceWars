using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Effects.MinionEffects;

namespace Assets.Scripts.Engine.Minions.Physics
{
    class RoboHookMinion_3sImmune : RoboHookMinion
    {

        public RoboHookMinion_3sImmune()
            : base()
        {

        }

        public override string getName()
        {
            return "Immune Robo Hook";
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

        public override void onHookStart()
        {
            // Server will add the robo hook immune effect   
        }
    }
}
