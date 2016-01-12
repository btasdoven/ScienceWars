using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.IGUI;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GEnterStartCountdown : IncomingMessageImp
    {
        public override void processMessage(RawMessage message)
        {
            float seconds = message.getFloat("s");
            Engine.Game.pauseTime = seconds;
            Engine.Game.setState( Engine.Game.GameState.STARTCOUNTDOWN );
			Runner.Graphics.displayStartCountDown(seconds);
        }
    }
}
