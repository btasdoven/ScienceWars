using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.GUI;
using NetWorker;
using NetWorker.Utilities;
using UnityEngine;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Login
{
    class LoginResult : IncomingMessageImp
    {
        public override void processMessage(RawMessage message)
        {
            bool result = message.getBool("r");

            if (result)
            {                
                UserMe.initializeUserMe(message.getInt("ui"),
                                        message.getUTF8String("un"),
                                        message.getInt("psp"),
                                        message.getInt("csp"),
                                        message.getInt("bsp"),
                                        message.getBoolArray("usn"));
            }
            else
                ;//TODO login fail. handle it
            
        }
    }
}