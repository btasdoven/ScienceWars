using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.ScienceTrees.ScienceNodes.Physics;
using Science_Wars_Server.ScienceTrees.ScienceNodes.Chemistry;
using Science_Wars_Server.ScienceTrees.ScienceNodes.Biology;

namespace Science_Wars_Server.ScienceTrees.ScienceNodes
{
    public abstract class ScienceNode
    {
        public static Dictionary<ScienceNode, int> scienceNodeDbIds = new Dictionary<ScienceNode, int>();
        public static Dictionary<Type, ScienceNode> scienceNodeInst = new Dictionary<Type, ScienceNode>();

        public List<ScienceNode> children;
        public ScienceNode parent;
        public int dbId;

        public abstract void unlock(User user);
        
        /// <summary>
        /// Static Constructor. 
        /// All science tree nodes should be created here.
        /// </summary>
        static ScienceNode()
        {                      
            createNode(new Gauss(), 0);
            createNode(new Newton(), 1);
            createNode(new Mendeleev(),2);
            createNode(new Darwin(),3);
        }

        public ScienceNode()
        {
            if(scienceNodeDbIds.ContainsKey(this))
                dbId = scienceNodeDbIds[this];
        }

        static private void createNode(ScienceNode node, int dbId)
        {
            scienceNodeDbIds.Add(node, dbId);
            scienceNodeInst.Add(node.GetType(), node);
        }

        public void AddChild(ScienceNode child)
        {
            children.Add(child);
            child.parent = this;
        }

        public ScienceNode getRoot()
        {
            ScienceNode tmp = this;

            while (tmp.parent != null)
                tmp = tmp.parent;

            return tmp;
        }
    }
}
