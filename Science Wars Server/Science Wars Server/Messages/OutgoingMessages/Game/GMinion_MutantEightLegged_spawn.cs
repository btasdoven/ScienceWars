using System.Collections.Generic;
using System.Linq;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Minions.Biology;
using Science_Wars_Server.Minions.Physics;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GMinion_MutantEightLegged_spawn : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, MutantEightLeggedMinion parentMinion, ICollection<MutantEightLeggedSpawningMinion> spawnedMinions, ICollection<Minion> deadMinions  )
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GMinion_MutantEightLegged_spawn)));

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            { 
                msg.putInt("iid", parentMinion.instanceId);
                msg.putInt("c", spawnedMinions.Count);

                int[] sid = new int[spawnedMinions.Count];
                for(int i=0; i< spawnedMinions.Count; i++)
                    sid[i] = spawnedMinions.ElementAt(i).instanceId;
                msg.putIntArray("sid", sid);

                int[] did = new int[deadMinions.Count];
                for (int i = 0; i < deadMinions.Count; i++)
                    did[i] = deadMinions.ElementAt(i).instanceId;
                msg.putIntArray("did",did);
                
                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }

        }
    }
}