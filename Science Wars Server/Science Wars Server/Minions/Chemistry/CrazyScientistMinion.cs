using System;
using System.Collections.Generic;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;


namespace Science_Wars_Server.Minions.Chemistry
{
    class CrazyScientistMinion : ChemistryMinion
    {
        private static int cost = 1350;
        private static int upgradeCost = 0;
        private static int income = 108;
        private static int killGold = 337;
        private static int healthCost = 1;
        private static float effectRange = 0.7f;
        private bool potUsed = false;

        public CrazyScientistMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.health = stats.healthTotal = 320;
            stats.baseMovementSpeed = 1.1f;
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.POISON, .8f) });
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
                        walk();

                        if (!potUsed)
                        {
                            foreach (var m in this.position.board.minions)
                            {
                                if (m.Value != this && (this.getWorldPosition() - m.Value.getWorldPosition()).magnitude < effectRange)
                                {
                                    CrazyScientistEffect effect = new CrazyScientistEffect();
                                    if(m.Value.addEffect(effect))
                                    {
                                        this.potUsed = true;
                                        Messages.OutgoingMessages.Game.GAddEffectOnMinion.sendMessage(this.game.players, m.Value, effect);
                                        break;
                                    }
                                }
                            }
                        }
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
