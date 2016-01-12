using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.IGUI;
using NetWorker;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages
{
    class EnterLobby : IncomingMessageImp
    {
        public override void processMessage(RawMessage message)
        {
            UserMe.self.setState(User.UserState.LOBBY);
            Runner.Graphics.loadLobby();
        }
    }
}
