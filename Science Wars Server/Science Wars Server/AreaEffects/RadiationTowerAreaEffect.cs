using Science_Wars_Server.Helpers;
using Science_Wars_Server.Strategies.TargetStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.AreaEffects
{
    class RadiationTowerAreaEffect : AreaEffect
    {
        private static float DURATION_DEFAUT = 0.5f;
        private static float RADIUS_DEFAULT = 3.0f;
        private static float DEFAULT_DAMAGE = 30.0f;

        private float remainingDuration;

        public RadiationTowerAreaEffect(Player ownerPlayer, Vector3 worldPosition)
            : base(ownerPlayer, worldPosition)
        {
            remainingDuration = DURATION_DEFAUT;
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
                        GameUtilities.Damage damageFire = new GameUtilities.Damage((DEFAULT_DAMAGE / dist) * Chronos.deltaTime, GameUtilities.DamageType.FIRE);
                        GameUtilities.Damage damagePoison = new GameUtilities.Damage((DEFAULT_DAMAGE / dist) * Chronos.deltaTime, GameUtilities.DamageType.POISON);
                        m.Value.dealDamage(damageFire, ownerPlayer,false);
                        m.Value.dealDamage(damagePoison, ownerPlayer,false);
                    }
                }

            remainingDuration -= Chronos.deltaTime;
            if (remainingDuration <= 0)
                destroyable = true;
        }
    }
}
