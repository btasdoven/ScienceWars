using UnityEngine;
using System.Collections;
using NetWorker.Utilities;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Minions.Physics;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    public class GMinion_FrankenScientist_stackChanged : IncomingMessageImp
    {

		#region implemented abstract members of IncomingMessageImp

		public override void processMessage (RawMessage message)
		{
            FrankenScientistMinion parentMinion = (FrankenScientistMinion) Engine.Game.getMinionById( message.getInt("iid"));
            int stackCount = message.getInt("c");           		   
            Runner.Graphics.minion_frankenScientist_stackChanged(parentMinion, stackCount);
		}

		#endregion


	}
}