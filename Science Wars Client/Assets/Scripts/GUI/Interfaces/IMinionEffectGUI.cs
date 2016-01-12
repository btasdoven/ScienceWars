using Assets.Scripts.Engine.AreaEffects;
using Assets.Scripts.Engine.Effects.MinionEffects;
using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using UnityEngine;

namespace Assets.Scripts.GUI.Interfaces
{
    public interface IMinionEffectGUI : IStep, IRequiresResourceGUI
	{
        void createMinionEffect(Minion minion, MinionEffect areaEffect);            
        bool isDestroyable();
	}
}

