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
	public class ContagiousTower_extraGUI : ContagiousTowerGUI
	{
		public ContagiousTower_extraGUI()
			: base(typeof(ContagiousTower_extra))	
		{
		}
		
		protected ContagiousTower_extraGUI(Type towerType)
			: base(towerType)
		{
		}
		
		public override string getUpgradeInfo()
		{
			return "Now, the minions effected by contagious tower can jump minions in " + makePositiveString("95") + " range.";
		}
		
		public override string getInfo()
		{
			return "This tower infects a virus to target minion. If the minion dies because of this virus then the virus is infected to all nearby minions within a range.";
		}
	}
}

