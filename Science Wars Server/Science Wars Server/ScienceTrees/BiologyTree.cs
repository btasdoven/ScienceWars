using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.ScienceTrees.ScienceNodes;
using Science_Wars_Server.ScienceTrees.ScienceNodes.Biology;

namespace Science_Wars_Server.ScienceTrees
{
    static public class BiologyTree
    {
        static public ScienceNode root;

        static BiologyTree()
        {
            root = ScienceNode.scienceNodeInst[typeof(Darwin)];            
        }
    }
}
