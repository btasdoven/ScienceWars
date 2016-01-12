using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Minions;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Effects.MinionEffects
{
    class ContagiousEffect : MinionEffect
    {
        public const float DAMAGE_OVER_1_SEC = 50.0f;
        
        private const float infectionRange = 0.7f;
        protected virtual float INFECTION_RANGE { get { return infectionRange; } }
        
        public const DamageType damageType = DamageType.FIRE;

        public ContagiousEffect(Player ownerPlayer)
        {
            remainingTime = 3.0f;
            this.ownerPlayer = ownerPlayer;
        }

        public override void step(Minions.Minion minion)
        {
            minion.dealDamage(new Damage(DAMAGE_OVER_1_SEC * Chronos.deltaTime, damageType),ownerPlayer, false);

            if (minion.minionState == Minion.MinionState.DEAD)
            {
                // if the minion is killed by this virus then infect this virus to nearby minions
                Vector3 minionPos = minion.getWorldPosition();
                foreach (var m in minion.position.board.minions)
                {
                    if (m.Value.minionState == Minion.MinionState.DEAD)
                        continue;

                    // calculate the distance of each minion to this minion
                    var dist = (m.Value.getWorldPosition() - minionPos).magnitude;

                    // if the minion in the range then add the effect
                    if (dist < INFECTION_RANGE)                                                                 // belli rangedeki minionlari bulmak icin target strategy kullanilabilir.
                    {
                        ContagiousEffect contEffect = new ContagiousEffect(ownerPlayer);
                        if (m.Value.addEffect(contEffect))
                            Messages.OutgoingMessages.Game.GAddEffectOnMinion.sendMessage(m.Value.game.players, m.Value, contEffect);
                        return;
                    }
                }
            }
        }

        public override bool isStackable()
        {
            return true;
        }

    }
}
