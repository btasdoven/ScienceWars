using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.IGUI;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GPaymentTimeInfo : IncomingMessageImp
    {

        public override void processMessage(NetWorker.Utilities.RawMessage message)
        {
            float payment = message.getFloat("s");
            Engine.Game.setPaymentTime(payment);
        }
    }
}
