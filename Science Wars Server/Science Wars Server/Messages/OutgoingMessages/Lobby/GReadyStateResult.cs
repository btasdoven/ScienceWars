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
    class GReadyStateResult : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> players,bool result)
        {
            RawMessage msg = new RawMessage();

            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GReadyStateResult)));
            msg.putBool("r", result);

            foreach (Player player in players)
                player.user.session.client.SendMessage(msg);
        }
    }
}
