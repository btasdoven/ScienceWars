//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using Assets.Scripts.GUI.Interfaces;
using Assets.Scripts.Engine.GameUtilities;
using System.Collections.Generic;

namespace Assets.Scripts.GUI.GUIUtilities
{
	public class TypeIdGeneratorGUI
	{
		public static Dictionary<int, IMinionGUI> minionGuiInst;
		public static Dictionary<int, ITowerGUI> towerGuiInst;

		static TypeIdGeneratorGUI ()
		{
			minionGuiInst = TypeIdGenerator.generateIdClassHashMap<IMinionGUI>();
			towerGuiInst = TypeIdGenerator.generateIdClassHashMap<ITowerGUI>();
		}
	}
}

