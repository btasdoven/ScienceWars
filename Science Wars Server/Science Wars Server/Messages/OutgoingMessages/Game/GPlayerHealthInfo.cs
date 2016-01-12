using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GPlayerHealthInfo : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, Player player)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GPlayerHealthInfo)));


            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                msg.putInt("h", player.healthPoints);
                msg.putInt("uid", player.user.id);
                
                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }

            
        }
    }
}
