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
	
	public class MutantEightLeggedMinion_WellFedGUI : MutantEightLeggedMinionGUI
	{
        public MutantEightLeggedMinion_WellFedGUI()
            : base(typeof(MutantEightLeggedMinion_WellFed))	
		{
		}

        public MutantEightLeggedMinion_WellFedGUI(Type minionType)
            : base(minionType)
        {
        }

        public override string getUpgradeInfo()
        {
            return "Movement speed increased to " + makePositiveString("1.1") + " and has " + makePositiveString("1350") + " health points.";
        }
	}
}