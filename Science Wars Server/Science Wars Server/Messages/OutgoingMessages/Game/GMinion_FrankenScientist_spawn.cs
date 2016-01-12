using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Minions.Physics;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GMinion_FrankenScientist_spawn : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, FrankenScientistMinion parentMinion, ScrapGolemMinion spawnedMinion)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GMinion_FrankenScientist_spawn)));

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            { 
                msg.putInt("iid", parentMinion.instanceId);
                if(spawnedMinion.ownerPlayer != null)
                    msg.putInt("uid", spawnedMinion.ownerPlayer.id);
                else
                    msg.putInt("uid", -1);
                msg.putInt("sid", spawnedMinion.instanceId);
                msg.putInt("bid", spawnedMinion.position.board.instanceId);
                msg.putInt("cid", spawnedMinion.position.pathPosition.pointIndex);
                msg.putFloat("t", spawnedMinion.position.pathPosition.ratio);

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }

        }
    }
}