using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.Engine.ResourceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Engine
{
    public static class Runner
    {
        public static IGraphics Graphics;

        public static void update()
        {
            Game.step();
        }
    }
}
