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
    public class ScrapGolemMinion_OverheatGUI : ScrapGolemMinionGUI
	{
		public ScrapGolemMinion_OverheatGUI()
            : base(typeof(ScrapGolemMinion_Overheat))	
		{
		}

        public ScrapGolemMinion_OverheatGUI(Type minionType)
            : base(minionType)
        {
           
        }

	}
}