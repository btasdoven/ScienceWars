using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.GameUtilities;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.OutgoingMessages.Game
{
    class GLoadingStateResult : OutgoingMessageImp
    {
        public static void sendMessage()
        {
            RawMessage msg = new RawMessage();
            msg.putInt("id", TypeIdGenerator.getMessageId(typeof(GLoadingStateResult)));
            Network.server.SendMessage(msg);
        }
    }
}
