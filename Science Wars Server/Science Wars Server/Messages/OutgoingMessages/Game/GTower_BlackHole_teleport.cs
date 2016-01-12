using System.Collections.Generic;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.AreaEffects;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Towers;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GTower_BlackHole_teleport : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers,Tower tower, ICollection<Minion> minionsToTeleport)
        {
            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                RawMessage msg = new RawMessage();
                msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GTower_BlackHole_teleport)));

                msg.putInt("iid", tower.instanceId);

                int[] ids = new int[minionsToTeleport.Count];

                int index = 0;
                foreach(var minion in minionsToTeleport)
                    ids[index++] = minion.instanceId;

                msg.putIntArray("miid", ids);

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }
        }
    }
}
