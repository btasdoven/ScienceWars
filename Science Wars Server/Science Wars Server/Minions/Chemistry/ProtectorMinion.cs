using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions.Chemistry
{
    public class ProtectorMinion : ChemistryMinion
    {
        private static int cost = 3500;
        private static int upgradeCost = 5000;
        private static int income = 139;
        private static int killGold = 1175;
        private static int healthCost = 1;

        private float DEFAULT_EFFECT_RADIUS = 2.0f;
        private float DEFAULT_EFFECT_COOLDOWN_TIME = 3.0f;
        private float effectCooldownTime;

        public ProtectorMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 1300;
            stats.baseMovementSpeed = 0.9f;
            effectCooldownTime = DEFAULT_EFFECT_COOLDOWN_TIME;
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

                        if (effectCooldownTime - Chronos.deltaTime <= 0)
                        {
                            effectCooldownTime = DEFAULT_EFFECT_COOLDOWN_TIME;
                            foreach (Player player in game.players)
                                foreach (var minion in player.board.minions)
                                {
                                    Vector3 minionCoor = minion.Value.getWorldPosition();
                                    float dist = (this.getWorldPosition() - minionCoor).magnitude;
                                    if (dist <= DEFAULT_EFFECT_RADIUS && minion.Value.minionState == MinionState.ALIVE)
                                    {
                                        ProtectorEffect effect = new ProtectorEffect();
                                        if (minion.Value.addEffect(effect))
                                            Messages.OutgoingMessages.Game.GAddEffectOnMinion.sendMessage(this.game.players, minion.Value, effect);
                                    }
                                }
                        }
                        else
                        {
                            effectCooldownTime -= Chronos.deltaTime;
                        }

                    }
                }
                else if (minionState == MinionState.DEAD && isReadyToDestroy()) // minionState i tekrar kontrol ettim. ne olur ne olmaz yeni bir state eklersek patlamasin.
                    onDestroy();
            }
        }    

        #region Getters
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

        #endregion
    }
}
