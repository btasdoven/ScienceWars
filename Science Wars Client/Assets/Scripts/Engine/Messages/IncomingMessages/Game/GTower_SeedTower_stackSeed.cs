using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.AreaEffects;
using Assets.Scripts.Engine.GameUtilities;
using UnityEngine;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.Engine.Towers.Biology;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
	class GTower_SeedTower_stackSeed : IncomingMessageImp
	{
		public override void processMessage(NetWorker.Utilities.RawMessage message)
		{
			SeedTower ownerTower = (SeedTower)Engine.Game.getBoardById(message.getInt("bid")).towers[message.getInt("iob")]; //TODO check yapmak lazim bu indexler dogru mu, bu element null mi gelmis.
			ownerTower.seedCountInStack = message.getInt("sc");
		}
	}
}
