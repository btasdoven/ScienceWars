using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.GUI.Interfaces;
using UnityEngine;

namespace Assets.Scripts.GUI.ResourceLoaderGUI
{
    public class ResourceLoaderGUI
    {
        private static bool alreadyLoaded = false;

        public static void loadResources()
        {
            if (!alreadyLoaded)
            {
                // find all classes that are inherited from IRequiresResource
                var type = typeof(IRequiresResourceGUI);
                var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
						.Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);

                // and load their resources
                foreach (Type t in types)
                {
                    IRequiresResourceGUI ii = (IRequiresResourceGUI)Activator.CreateInstance(t);
                    ii.loadResources();
                }
            }
        }
    }
}
