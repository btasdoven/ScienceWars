using System;
using System.Linq;
using Science_Wars_Server.ResourceManager;

namespace Science_Wars_Server
{

    public static class ResourceLoader
    {
        public static void loadResources()
        {

            // TODO - bu kod tamam iyi guzel calisiyor da, bu kod her board'i yaratiyor
            // ve kaynaklarini yukluyor. Ama kaynak yukleme islemi static path ve towerslots
            // degiskenlerini dolduruyor. Static parent'taki degiskenler her Board'a ozgu oluyorlar mi
            // arastirmak gerek. Bir de bu kod Board yaratip kaynaklari yukledigi icin, her yaratilan
            // bu tipteki board'in isini gorur mu bilemedim.
            
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
        }
    }
}
