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
	
	public class MutantEightLeggedMinion_FertileGUI : MutantEightLeggedMinionGUI
	{
        public MutantEightLeggedMinion_FertileGUI()
            : base(typeof(MutantEightLeggedMinion_Fertile))	
		{
		}

        public MutantEightLeggedMinion_FertileGUI(Type minionType)
            : base(minionType)
        {
        }

        public override string getInfo()
        {
            return "Fertile Mutant Eight Legged can create unlimited number of spawning from nearby dead bodies. Each spawning has " + makePositiveString("220") + 
                " health points, " + makePositiveString("1.1") + " movement speed, " + makePositiveString("0") + " health cost and (" + makePositiveString("10%")
                + ", " + makePositiveString("10%") + ", " +makePositiveString("10%") + ") (Physical, Fire, Posion) resistance.";
        }

        public override string getUpgradeInfo()
        {
            return "Spawning minions will have " + makePositiveString("1.1") + " movement speed and additional " + makePositiveString("10%") + " Physical, Fire and Posion resistance.";
        }
	}
}