using Assets.Scripts.Engine.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Engine.AreaEffects
{
    class SeedTowerAreaEffect : AreaEffect
    {
        private static float DURATION_DEFAUT = 5f;
        private static float RADIUS_DEFAULT = 0.75f;
        private static float ATTACK_COOLDOWN = 0.5f;

        private float remainingDuration;

        public SeedTowerAreaEffect(int instanceId, Player ownerPlayer, Vector3 worldPosition)
            : base(instanceId, ownerPlayer, worldPosition)
        {
            remainingDuration = DURATION_DEFAUT;
        }

        public override void step()
        {
            remainingDuration -= Chronos.deltaTime;
            if (remainingDuration <= 0)
                destroyable = true;
        }
    }
}
