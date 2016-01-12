using System;
using System.Collections.Generic;
using Science_Wars_Server.Boards;
using Science_Wars_Server.Effects;
using Science_Wars_Server.Effects.TowerEffects;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Strategies.TargetStrategies;

namespace Science_Wars_Server.Towers
{
    public abstract class Tower
    {
        protected static int idGenerator = 0;
        public int instanceId { get; protected set; }

        protected Tower(Board board, int indexOnBoard)
        {
            instanceId = idGenerator++;
            this.board = board;
            this.indexOnBoard = indexOnBoard;
            stats = new TowerStats();
            effects = new LinkedList<ITowerEffect>();
            targetStrategy = new NearestMinionTargetStrategy();
        }   

        public Board board;
        public int indexOnBoard;
        public bool destroyable;        // tower destroy edilmeye hazir oldugunda bu variable true donmeli.

        public LinkedList<ITowerEffect> effects;
        public TowerStats stats;

        /// <summary>
        /// Kulenin bir sonraki hedefini nasil sececegine karar veren strateji.
        /// </summary>
        protected ITargetStrategy targetStrategy;
    
        public abstract void step();
        public abstract int getCost();

        public virtual Vector3 getWorldPosition()
        {
            Vector3 point = board.getTowerSlots().positions[indexOnBoard];
            float Deg2Rad = (float) (Math.PI/180.0f);
            float posX = (float) (point.x * Math.Cos(Deg2Rad * board.rotation.y*-1) - point.z * Math.Sin(Deg2Rad * board.rotation.y*-1));
            float posZ = (float) (point.x * Math.Sin(Deg2Rad * board.rotation.y*-1) + point.z * Math.Cos(Deg2Rad * board.rotation.y*-1));

            return new Vector3(posX, point.y, posZ) + board.position;
        }

        public Vector3 getLocalPosition()
        {
            return board.getTowerSlots().positions[indexOnBoard];
        }
        /// <summary>
        /// This function applies all the effects effected to this tower and sets tower stats in each step.
        /// To override this function, basically rewrite it in the child class.
        /// </summary>
        protected virtual void applyEffects()
        {
            //sets multipliers and dividers to 1
            //stats.restore();  // bunu Game dongusunun en basinda yapiyoruz, yoksa area effect etkilerini siliyor.

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
            return stats.stunned;
        }
    }
}
