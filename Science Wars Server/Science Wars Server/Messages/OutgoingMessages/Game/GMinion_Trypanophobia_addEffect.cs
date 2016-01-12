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
    class GMinion_Trypanophobia_addEffect : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, Minion minion, float runBackTime)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GMinion_Trypanophobia_addEffect)));


            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                msg.putInt("iid", minion.instanceId);
                msg.putFloat("t", runBackTime);

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }
        }
    }
}
