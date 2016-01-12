using System.Collections.Generic;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Effects.MinionEffects;
using Science_Wars_Server.AreaEffects;
using Science_Wars_Server.Helpers;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GAddAreaEffect : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, AreaEffect areaEffect)
        {
            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                RawMessage msg = new RawMessage();
                msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GAddAreaEffect)));

                msg.putInt("iid", areaEffect.instanceId);
                msg.putInt("tid", TypeIdGenerator.getAreaEffectId(areaEffect.GetType()));
                msg.putInt("uid", areaEffect.ownerPlayer.user.id);

                Vector3 position = areaEffect.getWorldPosition();
                msg.putFloatArray("pos", new float[] { position.x, position.y, position.z });

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }
        }
    }
}
