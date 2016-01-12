using System;
using System.Collections.Generic;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;

namespace Science_Wars_Server.Minions.Physics
{
    class RoboHookMinion : PhysicsMinion
    {
        private static int cost = 1200;
        private static int upgradeCost = 0;
        private static int income = 104;
        private static int killGold = 75;
        private static int healthCost = 1;

        private const float _cooldown_to_hook_default = 5.0f;
        private const float _hook_range_default = 3f; // 3 birim otesindeki minionlara atlayabilir
        private const float _hook_speed_default = 1.5f; // saniyede 1.5 birim ilerleyecek

        protected virtual float  COOLDOWN_TO_HOOK_DEFAULT { get { return _cooldown_to_hook_default; } } 
        protected virtual float HOOK_RANGE_DEFAULT { get { return _hook_range_default;  } } 
        protected virtual float HOOK_SPEED_DEFAULT { get { return _hook_speed_default; } } 

        private Minion hookedTo;
        private float nextHookTime;
        private bool currentlyHooked = false;
        private Vector3 flyPosition;

        public RoboHookMinion(Game game, Player ownerPlayer) : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 250;
            stats.baseMovementSpeed = 0.8f;
            stats.setBaseResistances(new List<DamageResistance>(){new DamageResistance(DamageType.FIRE, .6f)});

            nextHookTime = 0;
        }

        public override void step()
        {
            if (destroyable == false)
            {
                if (minionState == MinionState.ALIVE)
                {
                    if (stats.health <= 0)
                    {
                        onDeath();
                    }
                    else
                    {
                        nextHookTime -= Chronos.deltaTime;
                        if (currentlyHooked == false && nextHookTime <= 0)
                        {
                            hookedTo = selectTargetToHookTo();
                            if (hookedTo != null)
                            {
                                flyPosition = getWorldPosition();   // bunu currentlyHooked = true dan sonra yaparsaniz patlar.
                                currentlyHooked = true;
                                onHookStart();
                                Messages.OutgoingMessages.Game.GMinion_RoboHook_hookToMinion.sendMessage(position.board.player.game.players, this, hookedTo);
                            }
                        }

                        if (currentlyHooked)
                        {
                            hookMove();
                        }
                        else
                            walk();
                    }
                }
                else if (minionState == MinionState.DEAD && isReadyToDestroy()) // minionState i tekrar kontrol ettim. ne olur ne olmaz yeni bir state eklersek patlamasin.
                    onDestroy();
            }
        }

        public virtual void onHookStart()
        {

        }

        private void hookMove()
        {
            float distanceToFly = Chronos.deltaTime * HOOK_SPEED_DEFAULT;
            Vector3 targetPosition = hookedTo.getWorldPosition();
            
            if ((flyPosition - targetPosition).magnitude < distanceToFly)
            {
                hookedTo.position.board.AddMinionSpecificPosition(this, hookedTo.position.pathPosition);
                hookedTo = null;
                currentlyHooked = false;
                nextHookTime = COOLDOWN_TO_HOOK_DEFAULT;
            }
            else
            {
                flyPosition += (targetPosition - flyPosition).normalized * distanceToFly;
            }
                
        }

        private Minion selectTargetToHookTo()
        {
            Minion targetedMinion = null;
            float bestDistance = HOOK_RANGE_DEFAULT;
            Vector3 currentPosition = getWorldPosition();
                        
            foreach (Minion minion in position.board.minions.Values)
            {
                if ((minion.position.pathPosition.pointIndex > position.pathPosition.pointIndex)           // bu minion bizim onumuzde mi?
                    || (minion.position.pathPosition.pointIndex == position.pathPosition.pointIndex && minion.position.pathPosition.ratio > position.pathPosition.ratio))// bu minion bizim onumuzde mi?
                {
                    float distance = (minion.getWorldPosition() - currentPosition).magnitude;   // ne kadar onumuzde?

                    if (targetedMinion != null && distance < bestDistance)        // bir onceki miniondan daha uzaktaysa bunu secelim, maksimum mesafeye gitmis oluruz.
                    {
                        targetedMinion = minion;
                        bestDistance = distance;
                    }
                    else if (targetedMinion == null && distance < bestDistance)
                    {
                        targetedMinion = minion;
                        bestDistance = distance;
                    }
                }
            }
            
            return targetedMinion;        
        }

        public override Vector3 getWorldPosition()
        {
            if (currentlyHooked)
                return flyPosition;
            else
                return base.getWorldPosition();
        }

        public override int getIncome()
        {
            return income;
        }

        public override int getKillGold()
        {
            return killGold;
        }

        public override int getHealthCost()
        {
            return healthCost;
        }

        public override int getCost()
        {
            return cost;
        }

        public override int getUpgradeCost()
        {
            return upgradeCost;
        }  
    }
}
