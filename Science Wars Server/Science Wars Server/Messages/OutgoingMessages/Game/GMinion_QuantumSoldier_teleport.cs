using System.Collections.Generic;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Effects.MinionEffects;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GMinion_QuantumSoldier_teleport : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, Minion minion, ICollection<Minion> otherMinions)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GMinion_QuantumSoldier_teleport)));
            

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                msg.putInt("iid", minion.instanceId);
                msg.putFloat("ds", 1.3f);

                int [] minionInstanceIDs = new int[otherMinions.Count];

                int index = 0;
                foreach (var minionTarget in otherMinions)
                {
                    minionInstanceIDs[index++] = minionTarget.instanceId;
                }

                msg.putIntArray("mids", minionInstanceIDs);

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }
        }
    }
}
