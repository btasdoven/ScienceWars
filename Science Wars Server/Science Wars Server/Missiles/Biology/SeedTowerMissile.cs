using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Towers;
using Science_Wars_Server.AreaEffects;

namespace Science_Wars_Server.Missiles.Biology
{
    class SeedTowerMissile : Missile
    {
        private int numOfTarget;
        private Vector3 targetPosition;

        public SeedTowerMissile(Tower ownerTower, Minion targetMinion, int numOfTarget)
            : base(ownerTower, targetMinion)
        {
            Random random = new Random();
            Vector3 offset = new Vector3((float)(random.NextDouble() - 0.5f) / 4.0f,
                                            0.0f,
                                            (float)(random.NextDouble() - 0.5f) / 4.0f);
            this.numOfTarget = numOfTarget;
            targetPosition = targetMinion.getWorldPosition() + offset;
            movementSpeed = 3.0f;
            damageList.Add(new Damage(0, DamageType.FIRE));
        }

        public override void step()
        {
            if (chase())
            {
                AreaEffect areaEffect = new SeedTowerAreaEffect(ownerTower, targetPosition, numOfTarget);
                Messages.OutgoingMessages.Game.GAddAreaEffect.sendMessage(ownerTower.board.player.game.players, areaEffect);
                ownerTower.board.player.game.addAreaEffect(areaEffect);
                destroyable = true;
            }
        }

        public override bool chase()
        {
            Vector3 minionPos = targetPosition;
            float distanceToWalk = movementSpeed * Chronos.deltaTime;

            float currentDistance = (minionPos - position).magnitude;

            if (currentDistance <= distanceToWalk)
            {
                position = minionPos;
                return true;
            }

            position += (minionPos - position).normalized * distanceToWalk;
            return false;

        }
    }
}
