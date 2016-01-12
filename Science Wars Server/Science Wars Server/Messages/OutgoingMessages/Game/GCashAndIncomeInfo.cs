using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GCashAndIncomeInfo : OutgoingMessageImp
    {
        public static void sendMessage(Player player)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GCashAndIncomeInfo)));

            msg.putInt("c", player.cash);
            msg.putInt("i", player.income);

            player.user.session.client.SendMessage(msg);
        }
    }
}
