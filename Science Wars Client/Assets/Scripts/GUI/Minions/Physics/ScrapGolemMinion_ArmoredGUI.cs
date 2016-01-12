using System.Net.Configuration;
using System.Security.Cryptography;
using UnityEngine;
using System.Collections;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.Minions.Physics;
using System;

namespace Assets.Scripts.GUI.Minions
{
    public class ScrapGolemMinion_ArmoredGUI : ScrapGolemMinion_OverheatGUI
	{
		public ScrapGolemMinion_ArmoredGUI() 
            : base(typeof(ScrapGolemMinion))	
		{
		}

        public ScrapGolemMinion_ArmoredGUI(Type minionType)
            : base(minionType)
        {
           
        }

	}
}