using System.Net.Configuration;
using System.Security.Cryptography;
using UnityEngine;
using System.Collections;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.Minions.Biology;
using System;

namespace Assets.Scripts.GUI.Minions
{
	
	public class MutantEightLeggedSpawningMinion_WellFedGUI : MutantEightLeggedSpawningMinionGUI
	{
        public MutantEightLeggedSpawningMinion_WellFedGUI()
            : base(typeof(MutantEightLeggedSpawningMinion_WellFed))	
		{
		}

        public MutantEightLeggedSpawningMinion_WellFedGUI(Type minionType)
            : base(minionType)
        {
        }

        public override string getInfo()
        {
            return "This minion can only be spawned by the Fertile Mutant Eight Legged minion.";
        }

        public override string getUpgradeInfo()
        {
            return "";
        }
		
	
	}
}