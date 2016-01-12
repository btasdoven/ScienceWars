using System.Collections.Generic;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Towers.Physics;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GTower_LaserTower_untarget : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, LaserTower tower, Minion targetedMinion)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GTower_LaserTower_untarget)));

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                msg.putInt("tiob", tower.indexOnBoard);
                msg.putInt("tbid", tower.board.instanceId);
                msg.putInt("miid", targetedMinion.instanceId);

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }
        }
    }
}
