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
	public class DroseraTower_insaneGUI : DroseraTower_crazyGUI
	{
		public DroseraTower_insaneGUI()
			: base(typeof(DroseraTower_insane))	
		{
		}
		
		protected DroseraTower_insaneGUI(Type towerType)
			: base(towerType)
		{
		}
		
		public override string getUpgradeInfo()
		{
			return "Now, drosera can eat minions " + makePositiveString("170") + " health per second";
		}
		
		public override string getInfo()
		{
			return "This gigantic plant can eat any minion have lifepoint less than 500 and consume it over 170 health per second. After digestion it is ready to attack again!";
		}
	}
}