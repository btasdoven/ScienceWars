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
	public class PhysicsStudentMinion_SuccessfulGUI : PhysicsStudentMinionGUI
	{		
        public PhysicsStudentMinion_SuccessfulGUI()
            : base(typeof(PhysicsStudentMinion_Successful))	
		{
		}

        public PhysicsStudentMinion_SuccessfulGUI(Type minionType)    //upgradeler icin
            : base(minionType)
        {
        }

        public override string getInfo()
        {
            return "Successful physics student is a more durable version of physics student.";
        }

        public override string getUpgradeInfo()
        {
            return "Health points increases to " + makePositiveString("120") + ".";
        }

	}
}