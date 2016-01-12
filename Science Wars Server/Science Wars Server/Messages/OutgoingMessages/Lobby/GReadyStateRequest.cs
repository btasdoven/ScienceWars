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
    class GReadyStateRequest : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> recievers)
        {
            RawMessage msg = new RawMessage();

            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GReadyStateRequest)));

            msg.putFloat("s", Science_Wars_Server.Game.READY_STATE_END_TIME_DEFAULT);

            foreach (Player p in recievers)
                p.user.session.client.SendMessage(msg);
        }
    }
}
