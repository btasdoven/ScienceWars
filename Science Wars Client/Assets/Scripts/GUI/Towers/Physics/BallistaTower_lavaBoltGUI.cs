using System;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Engine;
using Assets.Scripts.GUI;
using Assets.Scripts.Engine.Towers.Physics;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.GUI.Towers
{
	public class BallistaTower_lavaBoltGUI : BallistaTower_fireBoltGUI
	{
		public BallistaTower_lavaBoltGUI()
			: base(typeof(BallistaTower_lavaBolt))
		{
		}
		
		protected BallistaTower_lavaBoltGUI(Type towerType)
			: base(towerType)
		{
		}
		
		public override string getUpgradeInfo()
		{
			return "This upgrade increase the tower's fire damage to " + makePositiveString("50");
		}
		
		public override string getInfo()
		{
			return "This tower firing a bolt with a high fire damage to a single target in medium range.";
		}
	}
}

