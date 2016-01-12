using System.Collections.Generic;
using System.Collections.ObjectModel;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Helpers;
using Assets.Scripts.Engine.IGUI;
using UnityEngine;
using Assets.Scripts.Engine.Effects.MinionEffects;

namespace Assets.Scripts.Engine.Minions
{
    public abstract class Minion
    {
        // TODO MinionStats stats;
        public int instanceId;

        public IStep tag;
        
        public Player ownerPlayer;
        public bool destroyable;    // minion destroy edilmeye hazir oldugunda bu degerin true donmesi gerek.
		public enum MinionState
		{
			ALIVE, DEAD
		};
		
		public MinionState minionState = MinionState.ALIVE;

        public LinkedList<MinionEffect> effects;
        public MinionStats stats;

        public MinionPosition position;

        protected Minion()
        {
            stats = new MinionStats();
            effects = new LinkedList<MinionEffect>();
        }

        public virtual void step()
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

        public abstract int getCost();
        public abstract int getIncome();
        public abstract int getKillGold();
        public abstract int getHealthCost();
        public virtual int getUpgradeCost()
        {  
            return 0;
        }
        public abstract string getName();
        protected abstract float getLocalHeadHeight();

        public virtual void walk()
        {
            applyEffects(); // kanka applyEffects niye walk metodunda yapiliyor?

            float distance = stats.movementSpeed * stats.movementDirection * Chronos.deltaTime;

            if(stats.stunned == false)
                moveCustomDistance(distance);
        }

        /// <summary>
        /// Minionu verilen distance kadar ileriye isinlar. Distance degeri negatif de olabilir, bu durumda geriye isinlar.
        /// </summary>
        /// <param name="distance"></param>
        public void moveCustomDistance(float distanceToMove)
        {        
            const float step = 0.2f;       // 0.2 lik adimlar halinde buyuk hareketi kucuk parcalara boluyoruz.
            //bool notifyPlayers = false;

            while (distanceToMove != 0)
            {
                float distance = distanceToMove > 0 ? step : -step;
                if (System.Math.Abs(distanceToMove) < System.Math.Abs(distance))
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
                        position.board.AddMinionSpecificPosition(this, position.board.getPath().getStartPoint());     // yeni pathPosition degeri, bu fonksiyonun icerisinde zaten setleniyor. bizim pathPosition atamamiza gerek yok.
                        // minionu bir boarda eklemek, diger boarddan cikarilmasi islemini otomatik yapiyor. Bu sebeple prevBoard.RemoveMinion(this) dememize gerek yok.                    
                        // position.pathPosition = position.board.getPath().getStartPoint();       //Client'ta var diye ekledim.
                    }
                    /*  arkadaki boarda yurumesini istemiyoruz. bizim board'i terketmesin.
                    else if (distance < 0)
                    {
                        position.board = position.board.prevBoard;
                        position.board.AddMinionSpecificPosition(this, position.board.getPath().getEndPoint());     // yeni pathPosition degeri, bu fonksiyonun icerisinde zaten setleniyor. bizim pathPosition atamamiza gerek yok.
                        // minionu bir boarda eklemek, diger boarddan cikarilmasi islemini otomatik yapiyor. Bu sebeple prevBoard.RemoveMinion(this) dememize gerek yok.s
                        //position.pathPosition = position.board.getPath().getEndPoint();       //Client'ta var diye ekledim.
                    }*/
                    else
                        break;
                }
            }
        }

		public virtual void onDeath()
		{
			minionState = MinionState.DEAD;
            Runner.Graphics.minionDied(this);
		}

        protected virtual void applyEffects()
        {
            //sets multipliers and dividers to 1
            //stats.restore();

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

		public virtual Vector3 getWorldPosition()
		{
            //return Vector3.zero;
			return position.board.getPath().getWorldPosition(position);
		}

		public Vector3 getWorldHeadPosition()
		{
			return getWorldPosition() + new Vector3(0, getLocalHeadHeight(),0);
		}

        public virtual void dealDamage(Damage damage)
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
                if (stats.health > 0 && stats.health - damage.amount * damageReductionRatio>0)
                    stats.health -= damage.amount * damageReductionRatio; // resistance yoksa dogrudan hasari uygula
            }
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
