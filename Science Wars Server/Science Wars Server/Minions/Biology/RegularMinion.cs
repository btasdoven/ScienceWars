using System;
using System.Collections.Generic;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Minions.Biology
{
    public class RegularMinion : BiologyMinion
    {
        private static int cost = 40;
        private static int income = 8;
        private static int killGold = 40;
        private static int healthCost = 1;

        public RegularMinion(Game game, Player ownerPlayer) : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 100;
            stats.baseMovementSpeed = 0.7f;
            stats.setBaseResistances(new List<DamageResistance>(){new DamageResistance(DamageType.POISON, .8f)});
        }

        public override void step()
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
                }
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

        public override void dealDamage(MissileDamage damage)
        {
            float damageReductionRatio = 1;

            foreach (DamageResistance resistance in stats.getBaseResistances())
            {
                if(resistance.resistanceType == damage.damageType)// eger o resistance varsa...
                {
                    damageReductionRatio = resistance.damageReductionMultiplier;// orani degistir
                    break;
                }
            }

            stats.health -= damage.amount*damageReductionRatio; // resistance yoksa dogrudan hasari uygula

            Messages.OutgoingMessages.Game.GMinionHealthInfo.sendMessage(game.players, this);
        }

        public override int getCost()
        {
            return cost;
        }

        public void onDeath()
        {
            minionState = MinionState.DEAD;
            Messages.OutgoingMessages.Game.GDestroyMinionInfo.sendMessage(game.players,this);
            destroyable = true;
        }
    }
}
