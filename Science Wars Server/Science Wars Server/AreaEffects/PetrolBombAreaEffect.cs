using Science_Wars_Server.Helpers;
using Science_Wars_Server.Strategies.TargetStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.AreaEffects
{
    class PetrolBombAreaEffect : AreaEffect
    {
        private static float DURATION_DEFAUT = 7f;
        private static float RADIUS_DEFAULT = 1.5f;

        private float remainingDuration;

        public PetrolBombAreaEffect(Player ownerPlayer, Vector3 worldPosition)
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
                        GameUtilities.Damage damage = new GameUtilities.Damage(110.0f * Chronos.deltaTime / DURATION_DEFAUT,GameUtilities.DamageType.FIRE);
                        m.Value.dealDamage(damage,ownerPlayer,false);
                    }
                }

            remainingDuration -= Chronos.deltaTime;
            if (remainingDuration <= 0)
                destroyable = true;
        }
    }
}
