using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Effects.MinionEffects;

namespace Science_Wars_Server.Minions.Physics
{
    class QuantumSoldierMinion_Fast : QuantumSoldierMinion
    {
        public QuantumSoldierMinion_Fast(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
           
        }

        public override void onJumpEnded()
        {
            QuantumSoldierSpeedEffect speedEffect = new QuantumSoldierSpeedEffect();
            if (this.addEffect(speedEffect))
                Messages.OutgoingMessages.Game.GAddEffectOnMinion.sendMessage(this.game.players, this, speedEffect);
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

    }
}
