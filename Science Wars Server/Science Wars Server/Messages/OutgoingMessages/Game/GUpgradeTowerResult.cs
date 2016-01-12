using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Towers;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GUpgradeTowerResult : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, Tower tower, int upgradedTowerTypeId)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GUpgradeTowerResult)));

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                msg.putInt("tid", upgradedTowerTypeId);
                msg.putInt("bid", tower.board.instanceId);
                msg.putInt("iob", tower.indexOnBoard);

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }
        }
    }
}
