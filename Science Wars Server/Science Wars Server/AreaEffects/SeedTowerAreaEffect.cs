using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Messages.OutgoingMessages.Game;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Missiles.Biology;
using Science_Wars_Server.Strategies.TargetStrategies;
using Science_Wars_Server.Towers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.AreaEffects
{
    class SeedTowerAreaEffect : AreaEffect
    {
        private static float DURATION_DEFAUT = 5f;
        private static float RADIUS_DEFAULT = 0.75f;
        private static float ATTACK_COOLDOWN = 0.5f;

        private ITargetStrategy targetStrategy = new NearestMinionTargetStrategy();
        private float remainingDuration;
        private float nextAttackTime = 0;
        private int numOfTarget;
        private Tower ownerTower;

        public SeedTowerAreaEffect(Tower ownerTower, Vector3 worldPosition, int numOfTarget)
            : base(ownerTower.board.player, worldPosition)
        {
            this.ownerTower = ownerTower;
            this.numOfTarget = numOfTarget;
            remainingDuration = DURATION_DEFAUT;
        }

        public override void step()
        {            
            nextAttackTime -= Chronos.deltaTime;
            remainingDuration -= Chronos.deltaTime;

            if (remainingDuration <= 0)
            {
                destroyable = true;
                return;
            }

            if (nextAttackTime <= 0 && targetStrategy != null)
            {
                nextAttackTime = ATTACK_COOLDOWN;

                Collection<Minion> targetMinions = targetStrategy.selectTargetsFromBoard(ownerPlayer.board, getWorldPosition(), numOfTarget, 0, RADIUS_DEFAULT, MinionStateSelection.ALIVE);

                foreach (Minion minion in targetMinions)
                {
                    SeedTowerPlantMissile missile = new SeedTowerPlantMissile(ownerTower, worldPosition, minion);
                    if (ownerPlayer.game.missiles.ContainsKey(missile.instanceId) == false)
                        ownerPlayer.game.missiles.Add(missile.instanceId, missile);
                    GAreaEffect_SeedTowerAreaEffect_createMissile.sendMessage(ownerPlayer.game.players, missile);
                }
            }

            
        }
    }
}
