using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Missiles;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using UnityEngine;

namespace Assets.Scripts.GUI.Missiles
{
	public class OneToAll_toxicMissileGUI : MissileGUIImpl
	{
        private static GameObject staticMissileObject;
        private static GameObject staticMissileHitEffectObject;

        public OneToAll_toxicMissileGUI()
        {
            if (staticMissileObject != null)
            {
                childStaticMissileObject = staticMissileObject;
                childStaticMissileHitEffectObject = staticMissileHitEffectObject;
            }
        }

		public override void loadResources()
		{
            staticMissileObject = (GameObject)Resources.Load("3Ds/Missiles/OneToAllMissile/MissileObject");            
		}
	}
}

