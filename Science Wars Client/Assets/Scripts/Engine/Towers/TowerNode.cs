using Assets.Scripts.Engine.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Towers
{
    public class TowerNode
    {
        public Type towerType;
		public List<TowerNode> children = new List<TowerNode>();
        public TowerNode parent;

        /// <summary>
        /// Checks whether this tower node has a children with given id
        /// </summary>
        /// <param name="childId">Id of the child</param>
        /// <returns>If found, returns tower node of the child, otherwise returns null.</returns>
        TowerNode checkChildren(int childId)
        {
            foreach (TowerNode node in children)
                if (TypeIdGenerator.getTowerId(node.towerType) == childId)
                    return node;

            return null;
        }

        /// <summary>
        /// Checks whether this tower's parent is a node with given id as parameter.
        /// </summary>
        /// <param name="parentId">Id of the parent</param>
        /// <returns>If found, returns tower node of the parent, otherwise returns null.</returns>
        TowerNode checkParent(int parentId)
        {
            if (TypeIdGenerator.getTowerId(parent.towerType) == parentId)
                return parent;

            return null;
        }

        public TowerNode getRoot()
        {
            TowerNode tmp = this;

            while (tmp.parent != null)
            {
                tmp = tmp.parent;
            }

            return tmp;
        }
    }
}
