using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Towers;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GUpgradeMinionResult : OutgoingMessageImp
    {
        public static void sendMessage(Player receiverPlayer, int oldMinionTypeId, int upgradedMinionTypeId)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GUpgradeMinionResult)));

            if (receiverPlayer != null)
            {
                msg.putInt("tid", oldMinionTypeId);
                msg.putInt("utid", upgradedMinionTypeId);

                receiverPlayer.user.session.client.SendMessage(msg);
            }
        }
    }
}
