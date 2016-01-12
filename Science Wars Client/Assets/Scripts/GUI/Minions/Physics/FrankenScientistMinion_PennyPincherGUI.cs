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

namespace Assets.Scripts.GUI.Minions    // physics namespace icine koymadim, Activator.Instanciate derken Physics i gostermiyoruz suanda.
{
    public class FrankenScientistMinion_PennyPincherGUI : FrankenScientistMinionGUI
	{
		public FrankenScientistMinion_PennyPincherGUI() 
            : base(typeof(FrankenScientistMinion_PennyPincher))	
		{

		}

        public FrankenScientistMinion_PennyPincherGUI(Type minionType) // upgradelerin parent constructor cagirabilmesi icin
            : base(minionType)
        {

        }

        public override string getInfo()
        {
            return "Frankenscientist can collect nearby dead minions to create a " + makePositiveString("Scrap Golem") +
                   ". Each Scrap Golem requires " + makePositiveString("4") + " dead minions. This effect can occur only once. Scrap golem has " + makePositiveString("2000") +
                   " health points, " +
                   makePositiveString("0.6") + "movement speed, " + makePositiveString("1") + " health cost and "
                   + makePositiveString("40%") + " resistance to " + makePositiveString("all") + " damage types."; ;
        }

        public override string getUpgradeInfo()
        {
            return "Scrap Golem now requires " + makePositiveString("4") + " dead minions, instead of " +
                   makePositiveString("5");
        }
	}
}