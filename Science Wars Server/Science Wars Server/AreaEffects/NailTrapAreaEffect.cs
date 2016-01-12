using Science_Wars_Server.Helpers;
using Science_Wars_Server.Strategies.TargetStrategies;
using Science_Wars_Server.Effects.MinionEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.AreaEffects
{
    class NailTrapAreaEffect : AreaEffect
    {
        private static float DURATION_DEFAUT = 2.5f;
        private static float RADIUS_DEFAULT = 0.5f;
        // bu sayı slow miktarını ayarlıyor
        public float slowAmount = 0.75f;
        public float dmgPerSecond = 30.0f;

        private float remainingDuration;


        public NailTrapAreaEffect(Player ownerPlayer, Vector3 worldPosition,float slowAmount,float dmgPerSecond)
            : base(ownerPlayer, worldPosition)
        {
            remainingDuration = DURATION_DEFAUT;
            this.slowAmount = slowAmount;
            this.dmgPerSecond = dmgPerSecond;
        }

        public override void step()
        {
            foreach (var player in ownerPlayer.game.players)
                foreach (var m in player.board.minions)
                {
                    if (m.Value.minionState == Science_Wars_Server.Minions.Minion.MinionState.DEAD)
                        continue;

                    // calculate the distance of each minion to this minion
                    var dist = (m.Value.getWorldPosition() - worldPosition).magnitude;

                    // if the minion in the range then add deal damage
                    if (dist < RADIUS_DEFAULT)
                    {
                        GameUtilities.Damage damage = new GameUtilities.Damage(dmgPerSecond * Chronos.deltaTime, GameUtilities.DamageType.PHYSICAL);
                        // bu çok gecici bir şey olduğu için network'den yollamak sıkıntı yaratıcak latency'den dolayı bunun yerine client bu olayı simule edicek.
                        NailTrapSlowEffect slowEffect = new NailTrapSlowEffect(slowAmount);
                        m.Value.dealDamage(damage,ownerPlayer,false);
                        if(m.Value.addEffect(slowEffect))
                        {
                            Messages.OutgoingMessages.Game.GAddEffectOnMinionNailTrapSlow.sendMessage(m.Value.game.players, m.Value, slowEffect);
                        }
                    }
                }

            remainingDuration -= Chronos.deltaTime;
            if (remainingDuration <= 0)
                destroyable = true;
        }
    }
}
