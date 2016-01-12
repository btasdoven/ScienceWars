using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.Engine.Effects.TowerEffects;
using Assets.Scripts.Engine.GameUtilities;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
	class GAddEffectOnTower : IncomingMessageImp
	{
		public override void processMessage(NetWorker.Utilities.RawMessage message)
		{
			Board board = Engine.Game.getBoardById(message.getInt("bid"));
			Tower tower = board.towers[message.getInt("iob")];

			ITowerEffect effect = (ITowerEffect) Activator.CreateInstance(TypeIdGenerator.getTowerEffectClass(message.getInt("tid")));
			
			if (tower != null)
				tower.effects.AddLast(effect);
		}
	}
}
