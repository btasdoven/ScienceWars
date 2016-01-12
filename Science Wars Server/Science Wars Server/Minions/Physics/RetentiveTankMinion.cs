using System;
using System.Collections.Generic;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Towers;
using Science_Wars_Server.Effects.TowerEffects;

namespace Science_Wars_Server.Minions.Physics
{
    class RetentiveTankMinion : PhysicsMinion
    {
        private static int cost = 4500;
        private static int upgradeCost = 0;
        private static int income = 147;
        private static int killGold = 1125;
        private static int healthCost = 5;

        private static float NEXT_DISABLE_COOLDOWN_DEFAULT = 9.0f;
        private static float DISABLE_DISTANCE_DEFAULT = 1.5f;

        private float nextDisableTime;

        public RetentiveTankMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 920;
            stats.baseMovementSpeed = 0.5f;
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.POISON, .7f),
                                                                    new DamageResistance(DamageType.FIRE, .7f)});
        }

        public override void step()
        {
            if (destroyable == false)
            {
                if (minionState == MinionState.ALIVE)
                {
                    nextDisableTime -= Chronos.deltaTime;

                    if (stats.health <= 0)
                    {
                        onDeath();
                    }
                    else
                    {
                        if (nextDisableTime <= 0)
                        {
                            Vector3 pos = this.getWorldPosition();
                            foreach (Tower tower in this.position.board.towers)
                            {
                                if (tower != null && (tower.getWorldPosition() - pos).magnitude < DISABLE_DISTANCE_DEFAULT)
                                {
                                    RetentiveTankTowerEffect effect = new RetentiveTankTowerEffect();
                                    tower.effects.AddFirst(effect);
                                    Messages.OutgoingMessages.Game.GAddEffectOnTower.sendMessage(this.game.players, tower, effect);
                                    nextDisableTime = NEXT_DISABLE_COOLDOWN_DEFAULT;
                                    break;
                                }
                            }
                        }


                        walk();
                    }
                }
                else if (minionState == MinionState.DEAD && isReadyToDestroy()) // minionState i tekrar kontrol ettim. ne olur ne olmaz yeni bir state eklersek patlamasin.
                    onDestroy();
            }
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
