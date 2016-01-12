using UnityEngine;
using System.Collections;
using NetWorker.Utilities;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Minions.Physics;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    public class GMinion_FrankenScientist_spawn : IncomingMessageImp
    {

		#region implemented abstract members of IncomingMessageImp

		public override void processMessage (RawMessage message)
		{
            FrankenScientistMinion parentMinion = (FrankenScientistMinion) Engine.Game.getMinionById( message.getInt("iid"));
            ScrapGolemMinion minion = parentMinion.createScrapGolem();

		    User user = Assets.Scripts.Engine.Game.getUserById(message.getInt("uid"));
		    if (user != null)   // random minionlarda null gelebilir.
		        minion.ownerPlayer = user.player;

			minion.instanceId = message.getInt("sid");
			minion.position = new MinionPosition();
			minion.position.pathPosition = new PathPosition(0,0);
			minion.position.board = Assets.Scripts.Engine.Game.getBoardById( message.getInt ("bid"));
			minion.position.pathPosition.pointIndex = message.getInt("cid");
			minion.position.pathPosition.ratio = message.getFloat("t");

			minion.position.board.AddMinion(minion);
            Runner.Graphics.minion_frankenScientist_spawn(parentMinion, minion);
		}

		#endregion


	}
}