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

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GTower_LaserTower_target : IncomingMessageImp
	{
		public override void processMessage(NetWorker.Utilities.RawMessage message)
		{
            int minionInstanceId = message.getInt("miid");
            int boardId = message.getInt("tbid");
            int towerIndexOnBoard = message.getInt("tiob");

            Minion minion = Engine.Game.getMinionById(minionInstanceId);

            if (minion == null)
            {
                Debug.Log("LaserTower: targetlanacak minion oyunda yok!");
                return;
            }

            Board board = Engine.Game.getBoardById(boardId);

            if( board != null && board.towers.Length > towerIndexOnBoard && towerIndexOnBoard >= 0)
            {
                Tower tower = board.towers[towerIndexOnBoard];
                if (tower != null && tower is LaserTower)
                {
                    Runner.Graphics.tower_laserTower_target((LaserTower)tower, minion);
                }
            }
            
		}
	}
}
