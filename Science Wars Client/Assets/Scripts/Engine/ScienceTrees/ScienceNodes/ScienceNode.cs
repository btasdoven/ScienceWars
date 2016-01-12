using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.ScienceTrees.ScienceNodes
{
    public abstract class ScienceNode
    {
        public static Dictionary<Type, ScienceNode> scienceNodeInst;

        public List<ScienceNode> children = new List<ScienceNode>();
        ScienceNode parent;
        
        bool unlocked = false;

        public abstract void unlock();

        public void AddChild(ScienceNode child)
        {
            children.Add(child);
            child.parent = this;
        }
    }
}
