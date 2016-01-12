using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Towers;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.Strategies.TargetStrategies;

namespace Science_Wars_Server.Missiles.Physics
{
    class NitrogenBombMissile : Missile
    {
        Vector3 targetPosition = new Vector3();
        Vector3 speedDirection = new Vector3();
        float movementSpeed = 5.0f;         // total speed of the missile
        float strikeRange = 0.4f;             // strike range of the missile

        float gravity;

        public NitrogenBombMissile(Tower ownerTower, Minion targetMinion)
            : base(ownerTower, targetMinion)
        {
            position.y += 0.4f;             // catapult'un atis yuksekligi. Simdilik böyle yazdım. 
            // İleride bu yükseklik zımbırtısını nası atacaz server'a bakalım

            targetPosition = targetMinion.getWorldPosition();

            calcSpeedDirection();

            damageList.Add(new Damage(40, DamageType.PHYSICAL));
            damageList.Add(new Damage(40, DamageType.POISON));
        }

        public override void step()
        {
            if (destroyable != true && chase())
            {
                ICollection<Minion> targetsInRange = new ArbitraryMinionTargetStrategy().selectTargetsFromGame(this.ownerTower.board.player.game, targetPosition, int.MaxValue
                    , 0f, strikeRange, MinionStateSelection.ALIVE);

                foreach (var target in targetsInRange)
                {
                    foreach (var damage in damageList)
                        target.dealDamage(damage, ownerTower.board.player);

                    NitrogenBombEffect effect = new NitrogenBombEffect();
                    target.addEffect(effect);
                    Messages.OutgoingMessages.Game.GAddEffectOnMinion.sendMessage(this.ownerTower.board.player.game.players, target, effect);

                }
                destroyable = true;
            }
        }

        public override bool chase()
        {
            float distanceToWalk = speedDirection.magnitude * Chronos.deltaTime;

            float currentDistance = (targetPosition - position).magnitude;

            if (currentDistance <= distanceToWalk*2)
            {
                position = targetPosition;
                return true;
            }

            position += speedDirection * Chronos.deltaTime;
            speedDirection.y -= gravity * Chronos.deltaTime;
            return false;

        }

        private void calcSpeedDirection()
        {
            var distV = (targetPosition - position);
            distV.y = 0;
            var dist = distV.magnitude;
            var alpha = Math.PI / 4;

            var heightDiff = position.y - targetPosition.y;
            var t1 = heightDiff / movementSpeed * Math.Cos(alpha);
            var distExtra = Math.Sin(alpha) * movementSpeed * t1;

            gravity = (float)(Math.Sin(2 * alpha) * movementSpeed * movementSpeed / (dist - distExtra));

            speedDirection = (targetPosition - position).normalized;
            speedDirection.y = 0;
            speedDirection *= (float)Math.Cos(alpha) * movementSpeed;
            speedDirection.y = (float)Math.Sin(alpha) * movementSpeed;
        }
    }
}








