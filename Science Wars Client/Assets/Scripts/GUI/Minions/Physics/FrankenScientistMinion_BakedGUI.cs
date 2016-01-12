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
    public class FrankenScientistMinion_BakedGUI : FrankenScientistMinion_OnFireGUI
	{
		public FrankenScientistMinion_BakedGUI() 
            : base(typeof(FrankenScientistMinion_Baked))	
		{

		}

        public FrankenScientistMinion_BakedGUI(Type minionType)
            : base(minionType)
        {

        }

        public override string getInfo()
        {
            return "Frankenscientist can collect nearby dead minions to create a " +
                   makePositiveString("Over-Heated Scrap Golem") +
                   ". Each Scrap Golem requires " + makePositiveString("5") +
                   " dead minions. This effect can occur only once. Scrap golem has " + makePositiveString("2000") +
                   " health points, " +
                   makePositiveString("0.6") + "movement speed, " + makePositiveString("1") + " health cost and "
                   + makePositiveString("40%") + " resistance to " + makePositiveString("all") + " damage types.";
        }

        public override string getUpgradeInfo()
        {
            return "Now spawns Armored Scrap Golem which has " + makePositiveString("60%") +
                   " resistance to all damage types instead of " + makePositiveString("40%") + ".";
        }
    }
}