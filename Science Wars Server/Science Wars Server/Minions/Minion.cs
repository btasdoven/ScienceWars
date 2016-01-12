using System.Collections.Generic;
using System.Collections.ObjectModel;
using Science_Wars_Server.Boards;
using Science_Wars_Server.Effects;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Statistics;

namespace Science_Wars_Server.Minions
{
    public abstract class Minion
    {
        private static int idGenerator = 0;
        public int instanceId;
        public MinionPosition position;
        public Game game;
        protected Player killerPlayer;

        protected Minion(Game game, Player ownerPlayer)
        {
            this.game = game;
            instanceId = idGenerator++;
            this.ownerPlayer = ownerPlayer;
            stats = new MinionStats();
            effects = new LinkedList<MinionEffect>();
        }

        public Player ownerPlayer;
        public bool destroyable;    // minion destroy edilmeye hazir oldugunda bu variable true olmali.
        public enum MinionState
        {
            ALIVE, DEAD
        };

        public MinionState minionState = MinionState.ALIVE;

        private LinkedList<MinionEffect> effects;
        public MinionStats stats;

        public virtual void step()
        {
            if (destroyable == false)
            {
                if (minionState == MinionState.ALIVE)
                {
                    if (stats.health <= 0)
                        onDeath();
                    else
                        walk();
                }
                else if (minionState == MinionState.DEAD && isReadyToDestroy()) // minionState i tekrar kontrol ettim. ne olur ne olmaz yeni bir state eklersek patlamasin.
                    onDestroy();
            }
        }

        public abstract int getIncome();
        public abstract int getKillGold();
        public abstract int getHealthCost();
        public abstract int getCost();
        public abstract int getUpgradeCost();

        public virtual void walk()
        {
            applyEffects();

            float distance = stats.movementSpeed * stats.movementDirection * Chronos.deltaTime;
            
            if(isStunned() == false)
                moveCustomDistance(distance);            
        }

        /// <summary>
        /// Minionu verilen distance kadar ileriye isinlar. Distance degeri negatif de olabilir, bu durumda geriye isinlar.
        /// </summary>
        /// <param name="distance"></param>
        
        public void moveCustomDistance(float distanceToMove)
        {
            const float step = 0.2f;       // 0.2 lik adimlar halinde buyuk hareketi kucuk parcalara boluyoruz.
            bool notifyPlayers = false;

            while (distanceToMove != 0)
            {                
                float distance = distanceToMove>0?step:-step;
                if ( System.Math.Abs(distanceToMove) < System.Math.Abs(distance))
                {
                    distance = distanceToMove;
                    distanceToMove = 0;
                }
                else
                    distanceToMove -= distance;
                    

                while (true)
                {
                    distance = position.board.getPath().move(position.pathPosition, distance, out position.pathPosition);

                    if (distance > 0)
                    {
                        position.board = position.board.nextBoard;
                        position.board.AddMinion(this, false, false);     // yeni pathPosition degeri, bu fonksiyonun icerisinde zaten setleniyor. bizim pathPosition atamamiza gerek yok.
                        // minionu bir boarda eklemek, diger boarddan cikarilmasi islemini otomatik yapiyor. Bu sebeple prevBoard.RemoveMinion(this) dememize gerek yok.
                        position.board.prevBoard.player.decreaseHealth(getHealthCost());
                        position.pathPosition = position.board.getPath().getStartPoint();       //Client'ta var diye ekledim.

                        // STATCODE
                        if (ownerPlayer != null)
                        {
                            PlayerStats pStats = position.board.player.game.statTracker.getPlayerStatsOfPlayer(ownerPlayer);
                            pStats.minionsPassed += getHealthCost();
                        }

                        notifyPlayers = true;
                    }
                    // onceki board'a gitme durumu olmasin. gidebilecegi en arka nokta, boardin basi.
                    /*else if (distance < 0)
                    {
                        position.board = position.board.prevBoard;
                        position.board.AddMinion(this, true, false);     // yeni pathPosition degeri, bu fonksiyonun icerisinde zaten setleniyor. bizim pathPosition atamamiza gerek yok.
                        // minionu bir boarda eklemek, diger boarddan cikarilmasi islemini otomatik yapiyor. Bu sebeple prevBoard.RemoveMinion(this) dememize gerek yok.s
                        position.pathPosition = position.board.getPath().getEndPoint();       //Client'ta var diye ekledim.

                        notifyPlayers = true;
                    }*/
                    else
                        break;
                }
            }

            if (notifyPlayers)
                Messages.OutgoingMessages.Game.GMinionPositionInfo.sendMessage(position.board.player.game.players, this);
        }

        public bool addEffect(MinionEffect mEffect)
        {
            if (!mEffect.isStackable())
            {
                LinkedListNode<MinionEffect> effectNode = effects.First;
                while (effectNode != null)
                {
                    if(effectNode.Value.GetType() == mEffect.GetType())
                        return false;
                    effectNode = effectNode.Next;
                }

            }
            this.effects.AddFirst(mEffect);
            return true;
        }

        protected virtual void applyEffects()
        {
            //sets multipliers and dividers to 1
            //stats.restore();  // bunu Game dongusunun en basinda yapiyoruz, yoksa area effect etkilerini siliyor.

            LinkedListNode<MinionEffect> effectNode = effects.First;
            LinkedListNode<MinionEffect> tmpNode;

            while (effectNode != null)
            {
                effectNode.Value.step(this);
                effectNode.Value.remainingTime -= Chronos.deltaTime;

                if (effectNode.Value.remainingTime <= 0)
                {
                    tmpNode = effectNode;
                    effectNode = effectNode.Next;
                    effects.Remove(tmpNode);
                }
                else
                    effectNode = effectNode.Next;
            }

            stats.healthRegen *= stats.healthRegenDivider * stats.healthRegenMult;
            stats.movementSpeed *= stats.movementSpeedDivider * stats.movementSpeedMult;
            for (int i = 0; i < stats.resistances.Count; ++i)
                stats.resistances[i].damageReductionMultiplier *= stats.resistancesDivider[i] * stats.resistancesMult[i];
            
        }

        public virtual void dealDamage(Damage damage, Player damageDealer, bool notifyPlayer = true)
        {
            if (isInvulnerable() == false)
            {
                float damageReductionRatio = 1;

                foreach (DamageResistance resistance in stats.getBaseResistances())
                {
                    if (resistance.resistanceType == damage.damageType)// eger o resistance varsa...
                    {
                        damageReductionRatio = resistance.damageReductionMultiplier;// orani degistir
                        break;
                    }
                }

                stats.health -= damage.amount * damageReductionRatio; // resistance yoksa dogrudan hasari uygula

                if (stats.health <= 0 && stats.health + damage.amount * damageReductionRatio > 0)
                    killerPlayer = damageDealer;

                if(notifyPlayer)
                    Messages.OutgoingMessages.Game.GMinionHealthInfo.sendMessage(game.players, this);
            }
        }

        public virtual Vector3 getWorldPosition()
        {
            return position.board.getPath().getWorldPosition(position);
        }

        public virtual Vector3 getLocalPosition()
        {
            return position.board.getPath().getLocalPosition(position.pathPosition);
        }

        public virtual void onDeath()
        {
            minionState = MinionState.DEAD;
            Messages.OutgoingMessages.Game.GMinionHealthInfo.sendMessage(game.players,this);

            if (killerPlayer != null)
            {
                // STATCODE
                PlayerStats pStats = killerPlayer.game.statTracker.getPlayerStatsOfPlayer(killerPlayer);
                pStats.minionsKilled += 1;

                killerPlayer.addCash(getKillGold(), true);
            }
                
        }

        protected float remainingDestroyTime = 2f; // yerde 2sn'ye kalacaklar
        protected bool isReadyToDestroy()
        {
            remainingDestroyTime -= Chronos.deltaTime;

            if (remainingDestroyTime <= 0)
                return true;
            return false;
        }
        public virtual void onDestroy()
        {
            Messages.OutgoingMessages.Game.GDestroyMinionInfo.sendMessage(game.players, this);
            destroyable = true;
        }

        public virtual bool isInvulnerable()
        {
            return stats.invulnerable;
        }

        public virtual bool isUntargetable()
        {
            return stats.untargetable;
        }

        public virtual bool isStunned()
        {
            return stats.stunned;
        }

    }
}
