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
	public class OneToAllTower_toxicGUI : OneToAllTowerGUI
	{
		public OneToAllTower_toxicGUI()
			: base(typeof(OneToAllTower_toxic))	
		{
		}
		
		protected OneToAllTower_toxicGUI(Type towerType)
			: base(towerType)
		{
		}
		
		public override string getUpgradeInfo()
		{
			return "This tower can also apply extra " + makePositiveString("20") + " poison damage.";
		}
		
		public override string getInfo()
		{
			return "This tower attacks all minions in the range with extra poison damage.";
		}
	}
}

