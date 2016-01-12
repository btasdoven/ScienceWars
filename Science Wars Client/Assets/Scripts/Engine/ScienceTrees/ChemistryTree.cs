using Assets.Scripts.Engine.ScienceTrees.ScienceNodes;
using Assets.Scripts.Engine.ScienceTrees.ScienceNodes.Chemistry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.ScienceTrees
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
