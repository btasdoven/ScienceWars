using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GPaymentTimeInfo : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, float nextPaymentTime)
        {
            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                RawMessage msg = new RawMessage();
                msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GPaymentTimeInfo)));
                msg.putFloat("s", nextPaymentTime);

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }
        }
    }
}
