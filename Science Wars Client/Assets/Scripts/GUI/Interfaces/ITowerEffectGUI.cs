using Assets.Scripts.Engine.Effects.TowerEffects;
using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.GUI.ResourceLoaderGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.GUI.Interfaces
{
    public interface ITowerEffectGUI : IStep, IRequiresResourceGUI
    {
        void createTowerEffect(Tower tower, ITowerEffect areaEffect);
        bool isDestroyable();
    }
}
