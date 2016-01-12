using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Engine.Minions.Physics
{
	class RoboHookMinion : PhysicsMinion
	{
        private static int cost = 1200;
        private static int income = 104;
        private static int killGold = 75;
        private static int healthCost = 1;

        private const float _cooldown_to_hook_default = 5.0f; // sadece kullaniciya gostermek icin tutuyoruz, client engine bu bilgiyi kullanmiyor
        private const float _hook_range_default = 3f; // 3 birim otesindeki minionlara atlayabilir // sadece kullaniciya gostermek icin tutuyoruz, client engine bu bilgiyi kullanmiyor
        private const float _hook_speed_default = 1.5f; // saniyede 1.5 birim ilerleyecek   // sadece kullaniciya gostermek icin tutuyoruz, client engine bu bilgiyi kullanmiyor

        protected virtual float COOLDOWN_TO_HOOK_DEFAULT { get { return _cooldown_to_hook_default; } }
        protected virtual float HOOK_RANGE_DEFAULT { get { return _hook_range_default; } }
        protected virtual float HOOK_SPEED_DEFAULT { get { return _hook_speed_default; } } 

        private Minion hookedTo;
        private float nextHookTime;
        private bool currentlyHooked = false;
        private Vector3 flyPosition;

        public Minion hookedMinion
        {
            get
            {
                if (currentlyHooked == true)
                    return hookedTo;
                else
                    return null;
            }
            private set { }
        }

		public RoboHookMinion() : base()
		{
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.health= stats.healthTotal = 250;
            stats.baseMovementSpeed = 0.8f;
            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.FIRE, .6f) });

            nextHookTime = 0;
		}

		public override string getName ()
		{
			return "Robo Hook";
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
                    nextHookTime -= Chronos.deltaTime;      // sadece oyuncuya bilgi olsun diye azaltiyoruz. engine icin bir onemi yok

                    if (currentlyHooked)
                        hookMove();
                    else
                        walk();
                }
            }
		}

        public void hook(Minion minion)
        {
            flyPosition = getWorldPosition();
            currentlyHooked = true;
            hookedTo = minion;
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
        
        public override Vector3 getWorldPosition()
        {
            if (currentlyHooked)
                return flyPosition;
            else
                return base.getWorldPosition();
        }

		public override int getCost()
		{
			return cost;
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

		#region implemented abstract members of Minion
		
		protected override float getLocalHeadHeight ()
		{
			return 0.3f;
		}
		
		#endregion
	}
}
