using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GPlayerHealthInfo : IncomingMessageImp
    {

        public override void processMessage(NetWorker.Utilities.RawMessage message)
        {
            Player p = Engine.Game.getUserById(message.getInt("uid")).player;

            if(p!= null)
                Engine.Game.setPlayerHealth(p, message.getInt("h"));
        }
    }
}
