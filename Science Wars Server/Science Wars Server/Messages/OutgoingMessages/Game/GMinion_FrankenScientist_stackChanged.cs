using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Minions.Physics;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GMinion_FrankenScientist_stackChanged : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, FrankenScientistMinion minion, int stackCount)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GMinion_FrankenScientist_stackChanged)));

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            { 
                msg.putInt("iid", minion.instanceId);                
                msg.putInt("c", stackCount);

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }

        }
    }
}