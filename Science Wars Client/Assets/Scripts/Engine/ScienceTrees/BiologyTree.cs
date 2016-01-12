using Assets.Scripts.Engine.ScienceTrees.ScienceNodes;
using Assets.Scripts.Engine.ScienceTrees.ScienceNodes.Biology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.ScienceTrees
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
