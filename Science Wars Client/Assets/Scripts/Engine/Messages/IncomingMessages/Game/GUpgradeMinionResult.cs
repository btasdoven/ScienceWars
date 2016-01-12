using UnityEngine;
using System.Collections;
using NetWorker.Utilities;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Minions;
using System;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
	public class GUpgradeMinionResult : IncomingMessageImp {

		#region implemented abstract members of IncomingMessageImp

		public override void processMessage (RawMessage message)
		{
            Type currentMinionType = TypeIdGenerator.getMinionType(message.getInt("tid"));
            Type upgradedMinionType = TypeIdGenerator.getMinionType(message.getInt("utid"));


            for (int i = 0; i < PlayerMe.availableMinionTypes.Count; i++)
            {
                if (currentMinionType == PlayerMe.availableMinionTypes[i])
                {
                    PlayerMe.availableMinionTypes[i] = upgradedMinionType;
                    break;
                }
            }
			Runner.Graphics.upgradeMinion(currentMinionType,upgradedMinionType);
		}

		#endregion


	}
}