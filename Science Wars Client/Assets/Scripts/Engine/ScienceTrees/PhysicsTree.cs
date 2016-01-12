using Assets.Scripts.Engine.ScienceTrees.ScienceNodes;
using Assets.Scripts.Engine.ScienceTrees.ScienceNodes.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.ScienceTrees.ScienceNodes.Biology;
using Assets.Scripts.Engine.ScienceTrees.ScienceNodes.Chemistry;

namespace Assets.Scripts.Engine.ScienceTrees
{
    static public class PhysicsTree
    {
        static public ScienceNode root;
        
        static PhysicsTree()
        {
            root = ScienceNode.scienceNodeInst[typeof(Newton)];
            root.AddChild(ScienceNode.scienceNodeInst[typeof(Gauss)]);            
			root.AddChild (ScienceNode.scienceNodeInst[typeof(Mendeleev)]); 
			root.children[0].AddChild (ScienceNode.scienceNodeInst[typeof(Darwin)]); 
            //root.AddChild( ScienceNode.scienceNodeInst[typeof(Einstain)] );
            //root.children[1].AddChild( ScienceNode.scienceNodeInst[typeof(Fourier)] );
            //root.children[1].children[0].AddChild( ScienceNode.scienceNodeInst[typeof(Fatos)] );
        }
    }
}
