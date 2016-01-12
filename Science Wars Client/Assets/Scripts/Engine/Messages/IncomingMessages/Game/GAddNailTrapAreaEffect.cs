using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.AreaEffects;
using Assets.Scripts.Engine.GameUtilities;
using UnityEngine;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
	class GAddNailTrapAreaEffect : IncomingMessageImp
	{
		public override void processMessage(NetWorker.Utilities.RawMessage message)
		{
			int instanceId = message.getInt("iid");
			int typeId = message.getInt("tid");
			User ownerUser = Engine.Game.getUserById(message.getInt("uid"));
			float[] position = message.getFloatArray("pos");
			float dmgPerSecond = message.getFloat ("dps");
			float slowAmount = message.getFloat ("sa");
			
			if (ownerUser != null)
			{
				NailTrapAreaEffect areaEffect = new NailTrapAreaEffect(instanceId,ownerUser.player,new Vector3(position[0],position[1],position[2]),slowAmount,dmgPerSecond);
				Engine.Game.AddAreaEffect(areaEffect);
				Runner.Graphics.createAreaEffect(areaEffect);                
			}
		}
	}
}
