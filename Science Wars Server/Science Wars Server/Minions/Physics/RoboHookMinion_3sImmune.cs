using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Effects.MinionEffects;

namespace Science_Wars_Server.Minions.Physics
{
    class RoboHookMinion_3sImmune : RoboHookMinion
    {

        public RoboHookMinion_3sImmune(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
           
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

        public override void onHookStart()
        {
            RoboHookImmuneEffect minionEffect = new RoboHookImmuneEffect();
            if(this.addEffect(minionEffect))
                Messages.OutgoingMessages.Game.GAddEffectOnMinion.sendMessage(this.game.players, this, minionEffect);
        }

    }
}
