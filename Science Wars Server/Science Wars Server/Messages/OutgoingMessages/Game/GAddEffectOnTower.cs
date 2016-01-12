using System.Collections.Generic;
using NetWorker.Utilities;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Towers;
using Science_Wars_Server.Effects.TowerEffects;

namespace Science_Wars_Server.Messages.OutgoingMessages.Game
{
    class GAddEffectOnTower : OutgoingMessageImp
    {
        public static void sendMessage(ICollection<Player> receiverPlayers, Tower tower, ITowerEffect effect)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GAddEffectOnTower)));

            if (receiverPlayers != null && receiverPlayers.Count != 0)
            {
                msg.putInt("bid", tower.board.instanceId);
                msg.putInt("iob", tower.indexOnBoard);
                msg.putInt("tid", TypeIdGenerator.getTowerEffectId(effect.GetType()));

                foreach (var receiverPlayer in receiverPlayers)
                    receiverPlayer.user.session.client.SendMessage(msg);
            }
        }
    }
}
