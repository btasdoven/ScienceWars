using System.Collections.Generic;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Towers;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Towers.Biology;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GTower_SeedTower_stackSeed : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, SeedTower tower)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GTower_SeedTower_stackSeed)));

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                msg.putInt("bid", tower.board.instanceId);
                msg.putInt("iob", tower.indexOnBoard);
                msg.putInt("sc", tower.seedCountInStack);

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }
        }
    }
}
