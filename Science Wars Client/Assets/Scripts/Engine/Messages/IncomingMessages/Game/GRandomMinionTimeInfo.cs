using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.IGUI;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GRandomMinionTimeInfo : IncomingMessageImp
    {
        public override void processMessage(NetWorker.Utilities.RawMessage message)
        {
            float randomMinion = message.getFloat("s");
            Engine.Game.setRandomMinionTime(randomMinion);
        }
    }
}
