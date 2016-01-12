using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Towers;

namespace Science_Wars_Server.Missiles.Physics
{
    class CatapultMissile : Missile
    {
        Vector3 targetPosition = new Vector3();
        Vector3 speedDirection = new Vector3();
        float movementSpeed = 5.0f;         // total speed of the missile
        float strikeRange = 0.4f;             // strike range of the missile
        
        float gravity;

        public CatapultMissile(Tower ownerTower, Minion targetMinion) : base(ownerTower, targetMinion)
        {
            position.y += 0.4f;             // catapult'un atis yuksekligi. Simdilik böyle yazdım. 
                                            // İleride bu yükseklik zımbırtısını nası atacaz server'a bakalım

            targetPosition = targetMinion.getWorldPosition();

            calcSpeedDirection();
            
            damageList.Add(new Damage(20,DamageType.PHYSICAL));
        }

        public override void step()
        {
            if (chase())
            {
                foreach (var p in targetMinion.game.players)            
                {                                           // iterate over all minions in the game
                    foreach (var m in p.board.minions)
                    {
                        // calculate the distance of each minion to the targetPosition
                        var dist = (m.Value.getWorldPosition() - targetPosition).magnitude;

                        // if the minion in the range then deal damage
                        if (dist < strikeRange)
                            foreach (var damage in damageList)
                                targetMinion.dealDamage(damage,ownerTower.board.player);
                    }
                }

                destroyable = true;
            }
        }

        public bool chase()
        {
            float distanceToWalk = speedDirection.magnitude * Chronos.deltaTime;

            float currentDistance = (targetPosition - position).magnitude;

            if (currentDistance <= distanceToWalk)
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
            var alpha = Math.PI/4;

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








