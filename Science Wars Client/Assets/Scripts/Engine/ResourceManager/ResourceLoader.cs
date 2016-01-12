using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.ResourceManager
{
    class ResourceLoader
    {
		private static bool loaded = false;
        public static void loadResources()
        {
			if( loaded == false)
			{
	            // find all classes that are inherited from IRequiresResource
	            var type = typeof(IRequiresResource);
	            var types = AppDomain.CurrentDomain.GetAssemblies()
	                .SelectMany(s => s.GetTypes())
	                .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);

	            // and load their resources
	            foreach (Type t in types)
	            {
	                IRequiresResource ii = (IRequiresResource)Activator.CreateInstance(t);
	                ii.loadResources();
	            }
				loaded = true;
			}


        }
    }
}
