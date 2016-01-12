using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.Engine.GameUtilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    class GUpgradeTowerResult : IncomingMessageImp
    {
        public override void processMessage(NetWorker.Utilities.RawMessage message)
        {
			Tower tower = (Tower)System.Activator.CreateInstance( TypeIdGenerator.getTowerType( message.getInt("tid")));
			tower.indexOnBoard = message.getInt("iob");

			Board board = Assets.Scripts.Engine.Game.getBoardById( message.getInt ("bid"));

			Tower oldTower = board.towers[tower.indexOnBoard];
			if( oldTower!= null)
				oldTower.destroyable = true;

			if(	board.AddTower(tower,tower.indexOnBoard))
				Runner.Graphics.upgradeTower(tower);

        }
    }
}
