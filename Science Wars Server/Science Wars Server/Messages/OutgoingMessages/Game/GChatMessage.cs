using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorker;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GChatMessage : OutgoingMessageImp
    {
        public static void sendMessage(User user, string message)
        {
            RawMessage msg = new RawMessage();

            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GChatMessage)));
            msg.putUTF8String("s", user.username);
            msg.putUTF8String("m", message);

            foreach (Player p  in user.player.game.players)
                p.user.session.client.SendMessage(msg);
        }
    }
}
