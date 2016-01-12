using System.Collections.Generic;
using Assets.Scripts.Engine.Minions.Biology;
using UnityEngine;
using System.Collections;
using NetWorker.Utilities;
using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Minions.Physics;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Game
{
    public class GMinion_MutantEightLegged_spawn : IncomingMessageImp
    {

		#region implemented abstract members of IncomingMessageImp

		public override void processMessage (RawMessage message)
		{
            MutantEightLeggedMinion parentMinion = (MutantEightLeggedMinion) Engine.Game.getMinionById( message.getInt("iid"));

		    int spawningCount = message.getInt("c");

		    if (spawningCount == 0)
		        return;

		    int[] spawningIds = message.getIntArray("sid");
		    int[] deadIds = message.getIntArray("did");

            List<MutantEightLeggedSpawningMinion> spawnings = new List<MutantEightLeggedSpawningMinion>();
		    MutantEightLeggedSpawningMinion spawning;
		    Minion deadMinion;
		    for (int i = 0; i < spawningCount; i++)
		    {
		        deadMinion = Engine.Game.getMinionById(deadIds[i]);
		        if (deadMinion != null)
		        {
		            spawning = parentMinion.createSpawning();
		            spawning.instanceId = spawningIds[i];
                    spawnings.Add(spawning);
		            deadMinion.position.board.AddMinionSpecificPosition(spawning, deadMinion.position.pathPosition);
		        }
                
		    }

            Runner.Graphics.minion_mutantEightLegged_spawn(parentMinion,spawnings);
		}

		#endregion


	}
}