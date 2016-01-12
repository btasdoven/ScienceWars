using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Messages.OutgoingMessages.Game;
using Science_Wars_Server.ScienceTrees.ScienceNodes;
using Science_Wars_Server.Database;

namespace Science_Wars_Server.Messages.IncomingMessages.Lobby
{
    class LUnlockNodeRequest : IncomingMessageImp
    {
        public override void processMessage(NetWorker.Utilities.RawMessage message, User user)
        {
            int nodetypeid = message.getInt("tid");
            // Get type of science node to access its ScienceNode instance.
            // Find parent of it and check if the user has already unlocked it or not.
            // If successfull access database and change it.
            try
            {
                Type nodeType = TypeIdGenerator.getScienceNodeTypes(nodetypeid);
                ScienceNode newNode = ScienceTrees.ScienceNodes.ScienceNode.scienceNodeInst[nodeType];

                //int parentNodeId = TypeIdGenerator.getScienceNodeIds(newNode.parent.GetType());
                //if (user.unlockedScienceNodes[parentNodeId] && !user.unlockedScienceNodes[nodetypeid] )
                if (!user.unlockedScienceNodes[nodetypeid])
                {
                    // TODO: try to spend science points
                    user.unlockedScienceNodes[nodetypeid] = true;
                    bool[] unlockedScienceNodesWithDdId = new bool[user.unlockedScienceNodes.Length];
                    for (int i = 0; i < user.unlockedScienceNodes.Length; i++ )
                    {

                        Type tmpNodeType = TypeIdGenerator.getScienceNodeTypes(i);
                        ScienceNode tmpNode = ScienceTrees.ScienceNodes.ScienceNode.scienceNodeInst[tmpNodeType];
                        int tmpDbId = ScienceNode.scienceNodeDbIds[tmpNode];
                        if (user.unlockedScienceNodes[i])
                            unlockedScienceNodesWithDdId[tmpDbId] = true;
                        else
                            unlockedScienceNodesWithDdId[tmpDbId] = false;

                    }
                    newNode.unlock(user);
                    Runner.dal.openScienceNode(user.id, unlockedScienceNodesWithDdId);
                    LUnlockNodeResult.sendMessage(user, true);              
                }
                else
                    LUnlockNodeResult.sendMessage(user,false);
            }

            catch
            {
                LUnlockNodeResult.sendMessage(user,false);
            }
            
        }
    }
}
