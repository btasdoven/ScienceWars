using System.Collections.Generic;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GMinionHealthInfo : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, Minion minion)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GMinionHealthInfo)));
            

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                msg.putInt("iid", minion.instanceId);
                msg.putFloat("h", minion.stats.health);
                
                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }

        }
    }
}
