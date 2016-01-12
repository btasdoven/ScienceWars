using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.ScienceTrees.ScienceNodes;
using Science_Wars_Server.ScienceTrees.ScienceNodes.Chemistry;

namespace Science_Wars_Server.ScienceTrees
{
    static public class ChemistryTree
    {
        static public ScienceNode root;

        static ChemistryTree()
        {
            root = ScienceNode.scienceNodeInst[typeof(Mendeleev)];
        }
    }
}
