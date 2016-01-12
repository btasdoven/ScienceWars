using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetWorker.Utilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GDestroyTowerInfo : IncomingMessageImp 
    {
        public override void processMessage(RawMessage message)
        {
            Board board = Engine.Game.getBoardById(message.getInt("bid"));
            
            if (board != null)
            {
                int index = message.getInt("iob");
                if (board.towers[index] != null)
                {
                    board.towers[index].destroyable = true;
                }
            }
        }
    }
}
