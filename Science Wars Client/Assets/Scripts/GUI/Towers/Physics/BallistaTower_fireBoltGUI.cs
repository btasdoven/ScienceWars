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
	public class BallistaTower_fireBoltGUI : BallistaTowerGUI
	{
		public BallistaTower_fireBoltGUI()
			: base(typeof(BallistaTower_fireBolt))	
		{
		}
		
		protected BallistaTower_fireBoltGUI(Type towerType)
			: base(towerType)
		{
		}

		public override string getUpgradeInfo()
		{
			return "This tower can also apply extra " + makePositiveString("25") + " fire damage.";
		}

		public override string getInfo()
		{
			return "This tower firing a flame bolt to a single target in medium range.";
		}
	}
}

