using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GMinionPositionInfo : IncomingMessageImp
    {
        public override void processMessage(NetWorker.Utilities.RawMessage message)
        {
            Minion minion = Engine.Game.getMinionById(message.getInt("iid"));
            Board board = Engine.Game.getBoardById(message.getInt("bid"));
            
			if (board != null && minion != null && !board.minions.ContainsKey(minion.instanceId))
                board.AddMinion(minion);

			if (minion != null)
			{
	            minion.position.pathPosition.pointIndex = message.getInt("cid");
	            minion.position.pathPosition.ratio = message.getFloat("t");
			}
        }
    }
}
