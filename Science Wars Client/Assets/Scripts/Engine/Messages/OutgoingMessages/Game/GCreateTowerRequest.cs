using Assets.Scripts.Engine.GameUtilities;
using NetWorker.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Messages.OutgoingMessages.Game
{
    class GCreateTowerRequest : OutgoingMessageImp
    {
        static public void sendMessage(int towerTypeId, int indexOnBoard)
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GCreateTowerRequest)));
            msg.putInt("tid", towerTypeId);
            msg.putInt("iob", indexOnBoard);
            Network.server.SendMessage(msg);
        }
    }
}
