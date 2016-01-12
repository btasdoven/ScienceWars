using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Effects.MinionEffects;

namespace Science_Wars_Server.Minions.Physics
{
    class QuantumSoldierMinion_Crew : QuantumSoldierMinion_Fast
    {
        public QuantumSoldierMinion_Crew(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
           
        }

        public override void onJumpEnded()
        {
            QuantumSoldierSpeedEffect speedEffect = new QuantumSoldierSpeedEffect();
            if (this.addEffect(speedEffect))
                Messages.OutgoingMessages.Game.GAddEffectOnMinion.sendMessage(this.game.players, this, speedEffect);

            int effectCount = 2;

            foreach (var m in this.position.board.minions)
            {
                if (m.Value != this && (this.getWorldPosition() - m.Value.getWorldPosition()).magnitude < APPLY_EFFECT_RANGE_DEFAULT)
                {
                    QuantumSoldierSpeedEffect newEffect = new QuantumSoldierSpeedEffect();
                    if(m.Value.addEffect(newEffect))
                    {
                        effectCount--;
                        Messages.OutgoingMessages.Game.GAddEffectOnMinion.sendMessage(this.game.players, m.Value, newEffect);
                    }

                    if (effectCount == 0)
                        break;
                }
            }

        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }
    }
}
