using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Minions
{
    public class MinionNode
    {
        public Type minionType;
        public List<MinionNode> children = new List<MinionNode>();
        public MinionNode parent;

        /// <summary>
        /// Checks whether this miinion node has a children with given id
        /// </summary>
        /// <param name="childId">Id of the child</param>
        /// <returns>If found, returns miinion node of the child, otherwise returns null.</returns>
        public MinionNode checkChildren(int childId)
        {
            foreach (MinionNode node in children)
                if (TypeIdGenerator.getMinionId(node.minionType) == childId)
                    return node;

            return null;
        }

        /// <summary>
        /// Checks whether this miinion's parent is a node with given id as parameter.
        /// </summary>
        /// <param name="parentId">Id of the parent</param>
        /// <returns>If found, returns miinion node of the parent, otherwise returns null.</returns>
        public MinionNode checkParent(int parentId)
        {
            if (TypeIdGenerator.getMinionId(parent.minionType) == parentId)
                return parent;

            return null;
        }

        public MinionNode getRoot()
        {
            MinionNode tmp = this;

            while (tmp.parent != null)
                tmp = tmp.parent;

            return tmp;
        }
    }
}
