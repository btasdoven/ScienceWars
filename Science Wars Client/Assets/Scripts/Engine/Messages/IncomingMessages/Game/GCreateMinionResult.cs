using UnityEngine;
using System.Collections;
using NetWorker.Utilities;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
	public class GCreateMinionResult : IncomingMessageImp {

		#region implemented abstract members of IncomingMessageImp

		public override void processMessage (RawMessage message)
		{
			int tid = message.getInt("tid");
			Minion minion = (Minion) System.Activator.CreateInstance( TypeIdGenerator.getMinionType( tid ));
            
		    User user = Assets.Scripts.Engine.Game.getUserById(message.getInt("uid"));
		    if (user != null)   // random minionlarda null gelebilir.
		    {
		        minion.ownerPlayer = user.player;

		        if (user.player == PlayerMe.self)
		        {
		            PlayerMe.income += minion.getIncome();
		            PlayerMe.cash -= minion.getCost();
					Runner.Graphics.updateCashAndIncome();
		        }
		    }

			minion.instanceId = message.getInt("iid");
			minion.position = new MinionPosition();
			minion.position.pathPosition = new PathPosition(0,0);
			minion.position.board = Assets.Scripts.Engine.Game.getBoardById( message.getInt ("bid"));
			minion.position.pathPosition.pointIndex = message.getInt("cid");
			minion.position.pathPosition.ratio = message.getFloat("t");

			minion.position.board.AddMinion(minion);
			Runner.Graphics.createMinion(minion);
		}

		#endregion


	}
}