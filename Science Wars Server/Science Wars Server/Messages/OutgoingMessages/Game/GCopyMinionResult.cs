using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GCopyMinionResult : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, Minion minion)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GCopyMinionResult)));

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                msg.putInt("iid", minion.instanceId);
                if( minion.ownerPlayer!= null)
                    msg.putInt("uid", minion.ownerPlayer.id);
                else
                    msg.putInt("uid", -1);
                msg.putInt("tid", TypeIdGenerator.getMinionId(minion.GetType()));
                msg.putInt("bid", minion.position.board.instanceId);
                msg.putInt("cid", minion.position.pathPosition.pointIndex);
                msg.putFloat("t", minion.position.pathPosition.ratio);

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }

        }
    }
}
