using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.GameUtilities
{
    public class DamageResistance
    {
        public DamageType resistanceType;
        public float damageReductionMultiplier;             //ornegin 0.7: gelen hasarin sadece yuzde 70'inden etkileniyor demek.

        public DamageResistance(DamageType resistanceType, float damageReductionMultiplier)
        {
            this.resistanceType = resistanceType;
            this.damageReductionMultiplier = damageReductionMultiplier;
        }
    }
}
