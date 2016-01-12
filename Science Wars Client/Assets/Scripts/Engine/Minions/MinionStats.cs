using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Minions
{
    public class MinionStats
    {
        // stats - movement speed, armor, movementDirection, health gibi degerler tutar
        // multipliers and dividers
        public float movementSpeedMult;
        public float movementSpeedDivider;

        public float healthRegenMult;
        public float healthRegenDivider;

        public List<float> resistancesMult;
        public List<float> resistancesDivider;

        // stats
        public float baseMovementSpeed;
        public float baseHealthRegen;
        public float baseMovementDirection = 1;

        public bool invulnerable;
        public bool stunned;
        public bool untargetable;

        private List<DamageResistance> baseResistances;

        public MinionStats()
        {
            baseResistances = new List<DamageResistance>();
            resistancesMult = new List<float>();
            resistancesDivider = new List<float>();
			if (resistances == null)
				resistances = new List<DamageResistance>();
			
			if (resistancesMult == null)
				resistancesMult = new List<float>();
			
			if (resistancesDivider == null)
				resistancesDivider = new List<float>();
        }

        public List<DamageResistance> getBaseResistances()
        {
            return baseResistances;
        }

        public void setBaseResistances(List<DamageResistance> damageResist)
        {
            if (resistances == null)
                resistances = new List<DamageResistance>();

            if (resistancesMult == null)
                resistancesMult = new List<float>();

            if (resistancesDivider == null)
                resistancesDivider = new List<float>();

            resistances.Clear();
            resistancesMult.Clear();
            resistancesDivider.Clear();

            foreach (DamageResistance dr in damageResist)
            {
                resistances.Add(dr);
                resistancesMult.Add(1);
                resistancesDivider.Add(1);
            }

            baseResistances = damageResist;
        }

        public float movementSpeed;
        public float healthRegen;
        public float movementDirection;
        public float health;
        public float healthTotal;

        public List<DamageResistance> resistances;

        public void restore()
        {
            movementDirection = baseMovementDirection;
            movementSpeed = baseMovementSpeed;
            healthRegen = baseHealthRegen;

            for (int i = 0; i < baseResistances.Count; ++i)
            {
                resistances[i].damageReductionMultiplier = baseResistances[i].damageReductionMultiplier;
                resistances[i].resistanceType = baseResistances[i].resistanceType;
                resistancesMult[i] = 1;
                resistancesDivider[i] = 1;
            }

            movementSpeedDivider = 1;
            movementSpeedMult = 1;
            healthRegenDivider = 1;
            healthRegenMult = 1;

            invulnerable = false;
            stunned = false;
            untargetable = false;
        }
    }
}
