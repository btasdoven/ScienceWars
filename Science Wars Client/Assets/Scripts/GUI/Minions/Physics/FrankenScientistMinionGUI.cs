using System.Collections.Generic;
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
	public class FrankenScientistMinionGUI : MinionGUIImp
	{
		
		private static GameObject staticMinionObject;
		private static Texture2D staticMinionIcon;
		private static Texture2D staticMinionInfo;
		private static Projector staticRangeProjector;

        protected GameObject[] sacs = null;

		public FrankenScientistMinionGUI() 
            : base(typeof(FrankenScientistMinion))	
		{
			if (staticMinionObject != null) 
			{
				childStaticMinionObject = staticMinionObject;
				childStaticMinionIcon = staticMinionIcon;
				childStaticMinionInfo = staticMinionInfo;
				childStaticRangeProjector = staticRangeProjector;
               
			}
            
		}

        public FrankenScientistMinionGUI(Type minionType) // upgradelerin parent constructor cagirabilmesi icin
            : base(minionType)
        {
            if (staticMinionObject != null)
            {
                childStaticMinionObject = staticMinionObject;
                childStaticMinionIcon = staticMinionIcon;
                childStaticMinionInfo = staticMinionInfo;
                childStaticRangeProjector = staticRangeProjector;                               
            }            
        }

        public override void createMinion(Minion minion)
        {
            base.createMinion(minion);
            findSacks();
        }

		#region IRequiresResourceGUI implementation
		
		public override void loadResources ()
		{
            staticMinionObject = (GameObject)Resources.Load("3Ds/Minions/Physics/FrankenScientistMinion/MinionObject");
            staticMinionIcon = Resources.Load<Texture2D>("3Ds/Minions/Physics/FrankenScientistMinion/GUI/minionIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
		}
		
		#endregion

        private void findSacks()
        {
            sacs = new GameObject[5];
            
            foreach (Transform t in minionObject.GetComponentsInChildren<Transform>(true))
            {
                if (t.name.StartsWith("sac_"))
                {
                    sacs[int.Parse(t.name.Split('_')[1]) - 1] = t.gameObject;
                }
            }
        }


        public virtual void updateStackCount(int stackCount)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i < stackCount)
                    sacs[i].SetActive(true);
                else
                    sacs[i].SetActive(false);
            }
        }

	    public override string getInfo()
	    {
	        return "Frankenscientist can collect nearby dead minions to create a " + makePositiveString("Scrap Golem") +
                   ". Each Scrap Golem requires " + makePositiveString("5") + " dead minions. This effect can occur only once. Scrap golem has " + makePositiveString("2000") +
                   " health points, " +
                   makePositiveString("0.45") + "movement speed, " + makePositiveString("1") + " health cost and "
                   + makePositiveString("40%") + " resistance to " + makePositiveString("all") + " damage types."; ;
	    }
	}
}