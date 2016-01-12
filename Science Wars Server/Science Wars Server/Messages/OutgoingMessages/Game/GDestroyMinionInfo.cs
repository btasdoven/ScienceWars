using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GDestroyMinionInfo : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, Minion minion)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GDestroyMinionInfo)));

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                msg.putInt("iid", minion.instanceId);

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }

        }
    }
}
