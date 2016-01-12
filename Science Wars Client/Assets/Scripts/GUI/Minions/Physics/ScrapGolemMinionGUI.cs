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
	public class ScrapGolemMinionGUI : MinionGUIImp
	{
		
		private static GameObject staticMinionObject;
		private static Texture2D staticMinionIcon;
		private static Texture2D staticMinionInfo;
		private static Projector staticRangeProjector;


		public ScrapGolemMinionGUI() 
            : base(typeof(ScrapGolemMinion))	
		{
			if (staticMinionObject != null) 
			{
				childStaticMinionObject = staticMinionObject;
				childStaticMinionIcon = staticMinionIcon;
				childStaticMinionInfo = staticMinionInfo;
				childStaticRangeProjector = staticRangeProjector;
			}
		}

        public ScrapGolemMinionGUI(Type minionType) // upgradelerin parent constructor cagirabilmesi icin
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

		#region IRequiresResourceGUI implementation
		
		public override void loadResources ()
		{
            staticMinionObject = (GameObject)Resources.Load("3Ds/Minions/Physics/ScrapGolemMinion/MinionObject");
            staticMinionIcon = Resources.Load<Texture2D>("3Ds/Minions/Physics/ScrapGolemMinion/GUI/minionIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
		}
		
		#endregion

	    public override string getInfo()
	    {
	        return "Scrap Golem can only be spawned by a Frankenscientist.";
	    }
	}
}