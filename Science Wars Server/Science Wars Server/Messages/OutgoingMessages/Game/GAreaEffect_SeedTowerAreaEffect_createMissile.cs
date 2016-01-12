using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Missiles;
using Science_Wars_Server.Missiles.Biology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GAreaEffect_SeedTowerAreaEffect_createMissile : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, SeedTowerPlantMissile missile)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GAreaEffect_SeedTowerAreaEffect_createMissile)));

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                msg.putInt("iid", missile.instanceId);
                msg.putFloat("x", missile.startWorldPosition.x);
                msg.putFloat("y", missile.startWorldPosition.y);
                msg.putFloat("z", missile.startWorldPosition.z);
                msg.putInt("tid", TypeIdGenerator.getMissileId(missile.GetType()));
                msg.putInt("mid", missile.targetMinion.instanceId);

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }
        }
    }
}
