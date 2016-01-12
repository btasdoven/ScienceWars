using System;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Engine;
using Assets.Scripts.GUI;
using Assets.Scripts.Engine.Towers.Biology;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.GUI.Towers
{
	public class ContagiousTower_effectiveGUI : ContagiousTowerGUI
	{
		public ContagiousTower_effectiveGUI()
			: base(typeof(ContagiousTower_effective))	
		{
		}
		
		protected ContagiousTower_effectiveGUI(Type towerType)
			: base(towerType)
		{
		}
		
		public override string getUpgradeInfo()
		{
			return "Now, contagious tower can damage minions over " + makePositiveString("4") + " seconds.";
		}
		
		public override string getInfo()
		{
			return "This tower infects a virus to target minion. If the minion dies because of this virus then the virus is infected to all nearby minions within a range.";
		}
	}
}

