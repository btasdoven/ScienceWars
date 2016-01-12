using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GDestroyMinionInfo : IncomingMessageImp
    {
        public override void processMessage(NetWorker.Utilities.RawMessage message)
        {
            Minion minion = Engine.Game.getMinionById(message.getInt("iid"));
            if(minion!=null)
                minion.destroyable = true;
        }
    }
}
