using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.AreaEffects;
using Assets.Scripts.Engine.GameUtilities;
using UnityEngine;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.Engine.Towers.Physics;
using Assets.Scripts.Engine.Towers.Biology;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
	class GTower_DroseraTower_Bite : IncomingMessageImp
	{
		public override void processMessage(NetWorker.Utilities.RawMessage message)
		{
			int minionInstanceId = message.getInt("miid");
			int boardId = message.getInt("tbid");
			int towerIndexOnBoard = message.getInt("tiob");
			
			Minion minion = Engine.Game.getMinionById(minionInstanceId);
            DroseraTower tower = (DroseraTower)Engine.Game.getBoardById(boardId).towers[towerIndexOnBoard];
            Runner.Graphics.tower_droseraTower_bite(tower, minion);
		}
	}
}
