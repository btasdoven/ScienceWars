using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.ScienceTrees.ScienceNodes;
using Science_Wars_Server.ScienceTrees.ScienceNodes.Physics;

namespace Science_Wars_Server.ScienceTrees
{
    static public class PhysicsTree
    {
        static public ScienceNode root;

        static PhysicsTree()
        {
            root = ScienceNode.scienceNodeInst[typeof(Newton)];
            root.AddChild( ScienceNode.scienceNodeInst[typeof(Gauss)] );
            //root.AddChild( ScienceNode.scienceNodeInst[typeof(Einstain)] );
            //root.children[1].AddChild( ScienceNode.scienceNodeInst[typeof(Fourier)] );
            //root.children[1].children[0].AddChild( ScienceNode.scienceNodeInst[typeof(Fatos)] );
        }
    }
}
