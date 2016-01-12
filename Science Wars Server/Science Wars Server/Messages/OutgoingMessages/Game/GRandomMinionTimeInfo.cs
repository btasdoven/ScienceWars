using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GRandomMinionTimeInfo : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GRandomMinionTimeInfo)));

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                msg.putFloat("s", receiverPlayers.ElementAt(0).game.nextRandomMinionTime);

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }
                
        }
    }
}
