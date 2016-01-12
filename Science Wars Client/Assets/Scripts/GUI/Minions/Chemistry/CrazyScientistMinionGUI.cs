using System.Net.Configuration;
using System.Security.Cryptography;
using UnityEngine;
using System.Collections;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.Minions.Chemistry;

namespace Assets.Scripts.GUI.Minions
{
	public class CrazyScientistMinionGUI : MinionGUIImp
	{
		private static GameObject staticMinionObject;
		private static Texture2D staticMinionIcon;
		private static Texture2D staticMinionInfo;
		private static Projector staticRangeProjector;


		public CrazyScientistMinionGUI() : base(typeof(CrazyScientistMinion))	
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
			staticMinionObject = (GameObject)Resources.Load("3Ds/Minions/Chemistry/CrazyScientistMinion/MinionObject"); 
			staticMinionIcon = Resources.Load<Texture2D>("3Ds/Minions/Chemistry/CrazyScientistMinion/GUI/minionIcon");
			staticRangeProjector = ((GameObject)Resources.Load ("3Ds/Scenes/Game/RangeProjector")).GetComponent<Projector>();
		}
		
		#endregion
		

    }
}