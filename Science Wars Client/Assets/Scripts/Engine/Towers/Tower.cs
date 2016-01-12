using System.Collections.Generic;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.Engine.Strategies.TargetStrategies;
using UnityEngine;
using Assets.Scripts.Engine.Helpers;
using Assets.Scripts.Engine.Effects.TowerEffects;

namespace Assets.Scripts.Engine.Towers
{
    public abstract class Tower
    {
        public int instanceId;
        
        public Board board;
        public int indexOnBoard;
        public bool destroyable;    // tower destroy edilmeye hazir oldugunda bu variable true donmeli.

        public LinkedList<ITowerEffect> effects;
        public TowerStats stats;

        /// <summary>
        /// Kulenin bir sonraki hedefini nasil sececegine karar veren strateji.
        /// </summary>
        protected ITargetStrategy targetStrategy;
        
        public IStep tag;       // cizim islemini yapacak gui nesnesi buraya gelecek

        public abstract void step();
        public abstract int getCost();
		public abstract string getName();

		public abstract float getRange();
		public abstract float getAttackCooldown();

        protected Tower()
        {            
            stats = new TowerStats();
            effects = new LinkedList<ITowerEffect>();
            targetStrategy = new NearestMinionTargetStrategy();
        } 

        public virtual Vector3 getWorldPosition()
        {
            Vector3 point = board.getTowerSlots().positions[indexOnBoard];

            float posX = point.x * Mathf.Cos(Mathf.Deg2Rad * board.rotation.y * -1) - point.z * Mathf.Sin(Mathf.Deg2Rad * board.rotation.y * -1);
            float posZ = point.x * Mathf.Sin(Mathf.Deg2Rad * board.rotation.y * -1) + point.z * Mathf.Cos(Mathf.Deg2Rad * board.rotation.y * -1);

            return new Vector3(posX, point.y, posZ) + board.position;
        }

		protected abstract float getLocalMissileCreateHeight();

		public Vector3 getWorldMissileCreatePosition()
		{
			return getWorldPosition() + new Vector3(0, getLocalMissileCreateHeight(),0);
		}



        /// <summary>
        /// This function applies all the effects effected to this tower and sets tower stats in each step.
        /// To override this function, basically rewrite it in the child class.
        /// </summary>
        protected virtual void applyEffects()
        {
            //sets multipliers and dividers to 1
            //stats.restore();

			LinkedListNode<ITowerEffect> effectNode = effects.First;
			LinkedListNode<ITowerEffect> tmpNode;

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

            stats.attackTimeReduction = Chronos.deltaTime;
            stats.attackTimeReduction *= stats.attackSpeedDivider * stats.attackSpeedMult;
            stats.range *= stats.rangeDivider * stats.rangeMult;
        }

		public virtual bool isStunned()
		{
			return this.stats.stunned;
		}
    }

}
