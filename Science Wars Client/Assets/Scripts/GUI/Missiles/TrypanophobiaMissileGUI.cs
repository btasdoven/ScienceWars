using Assets.Scripts.Engine.Missiles;
using Assets.Scripts.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.GUI.Missiles
{
    public class TrypanophobiaMissileGUI : MissileGUIImpl
    {
        private static GameObject staticMissileObject;
        private static GameObject staticMissileHitEffectObject;

        public TrypanophobiaMissileGUI()
        {
            if (staticMissileObject != null)
            {
                childStaticMissileObject = staticMissileObject;
                childStaticMissileHitEffectObject = staticMissileHitEffectObject;
            }
        }

        public override void loadResources()
        {
            staticMissileObject = (GameObject)Resources.Load("3Ds/Missiles/TrypanophobiaMissile/MissileObject");
            staticMissileHitEffectObject = (GameObject)Resources.Load("3Ds/Missiles/TrypanophobiaMissile/MissileHitEffectObject");
        }
    }
}
