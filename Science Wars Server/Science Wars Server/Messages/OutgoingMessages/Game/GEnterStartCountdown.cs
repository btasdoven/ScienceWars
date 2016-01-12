using System.Collections.Generic;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GEnterStartCountdown : OutgoingMessageImp
    {
        public static void sendMessage( ICollection<Player> receiverPlayers, float seconds)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GEnterStartCountdown)));
            msg.putFloat("s", seconds);
            
            foreach (var player in receiverPlayers)
                player.user.session.client.SendMessage(msg);
        }
    }
}
