using System.Collections.Generic;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Effects.MinionEffects;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GAddEffectOnMinion : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, Minion minion, MinionEffect effect)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GAddEffectOnMinion)));

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                msg.putInt("iid", minion.instanceId);
                msg.putInt("tid", TypeIdGenerator.getMinionEffectId(effect.GetType()));

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }
        }
    }
}
