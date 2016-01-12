using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.IGUI;
using Assets.Scripts.Engine.ResourceManager;
using NetWorker.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts.Engine;
using Assets.Scripts.Engine.Towers;
using Assets.Scripts.Engine.Minions;

namespace Assets.Scripts.Engine.Messages.IncomingMessages.Lobby
{
    class GLoadingStateRequest : IncomingMessageImp
    {
        public override void processMessage(RawMessage message)
        {
			ResourceLoader.loadResources();

			Engine.Game.players = new LinkedList<Player>();
			Engine.Game.statPlayers = new List<Player> ();
            Engine.Game.clearOldGameData();
			
			foreach (RawMessage msg in message.getRawMessageArray("users"))
			{
				int uid = msg.getInt("uid");
				
				Board board = (Board)Activator.CreateInstance(TypeIdGenerator.getBoardType(msg.getInt("btid")));
				//TODO exception handle et yukaridaki bi sinifin icinde. Eger hata gelmisse adamin clienti ya bozulmus 
				// ya oynanmis ya da eskimis demektir. ona gore bi hata mesaji bastir.
				board.scienceType = (ScienceType) Enum.Parse(typeof(ScienceType), msg.getUTF8String("st"));
				board.instanceId = msg.getInt("biid");
				
				if (uid == UserMe.self.id)
				{
					PlayerMe.self = new Player(msg.getInt("hps"), board);
					PlayerMe.cash = msg.getInt("cash");
					PlayerMe.income = msg.getInt("inc");
					PlayerMe.self.user = UserMe.self;
					UserMe.self.player = PlayerMe.self;

                    setAvailableMinionsOfPlayer();
                    setAvailableTowersOfPlayer();

					Engine.Game.players.AddLast(PlayerMe.self);
					Engine.Game.statPlayers.Add(PlayerMe.self);
					board.player = PlayerMe.self;
				}
				else
				{
					User u = new User(msg.getUTF8String("un"), uid, new Player(msg.getInt("hps"), board));
					u.player.user = u;
					board.player = u.player;
					Engine.Game.players.AddLast(u.player);
					Engine.Game.statPlayers.Add(u.player);
				}
			}

			float dist = Engine.Game.calculateBoardDistanceToCenter (Engine.Game.players.Count);
			for (int i=0; i<Engine.Game.players.Count; i++)
			{
				Vector3 rotation = new Vector3(0, i * 360.0f / Engine.Game.players.Count, 0);
				Engine.Game.players.ElementAt(i).board.rotation = rotation;
				
				Engine.Game.players.ElementAt(i).board.position = new Vector3(Mathf.Cos(-1*rotation.y * (Mathf.PI / 180.0f)) * dist, 0, Mathf.Sin(-1*rotation.y * (Mathf.PI / 180.0f)) * dist);
				Engine.Game.players.ElementAt(i).board.nextBoard = Engine.Game.players.ElementAt((i + 1)%Engine.Game.players.Count).board;
				Engine.Game.players.ElementAt(i).board.prevBoard = Engine.Game.players.ElementAt((i + Engine.Game.players.Count - 1) % Engine.Game.players.Count).board;
			}
			
			Engine.Game.setState(Engine.Game.GameState.LOADING);
		}

        private void setAvailableTowersOfPlayer()
        {
            Type root = null;

			switch (PlayerMe.self.board.scienceType)
            {
                case ScienceType.PHYS:
                    root = typeof(PhysicsTower);
                    break;
                case ScienceType.CHEM:
                    root = typeof(ChemistryTower);
                    break;
                case ScienceType.BIO:
                    root = typeof(BiologyTower);
                    break;
            }

			PlayerMe.availableTowerTypes = new List<Type>();
            for (int i = 0; i < UserMe.unlockedTowers.Length; i++)
            {
				if(UserMe.unlockedTowers[i])
				{
	                Type towerType = TypeIdGenerator.getTowerType(i);
                    TowerNode towerNode = TypeIdGenerator.getTowerNodeInsts(towerType);
                    if (UserMe.unlockedTowers[i] && towerNode.parent != null && towerNode.parent.towerType == root)
	                    PlayerMe.availableTowerTypes.Add(towerType);
				}
            }
        }

        private void setAvailableMinionsOfPlayer()
        {
            Type root = null;

            switch (PlayerMe.self.board.scienceType)
            {
                case ScienceType.PHYS:
                    root = typeof(PhysicsMinion);
                    break;
                case ScienceType.CHEM:
                    root = typeof(ChemistryMinion);
                    break;
                case ScienceType.BIO:
                    root = typeof(BiologyMinion);
                    break;
            }

			PlayerMe.availableMinionTypes = new List<Type>();
            for (int i = 0; i < UserMe.unlockedMinions.Length; i++)
            {
				if( UserMe.unlockedMinions[i] )
				{
	                Type minionType = TypeIdGenerator.getMinionType(i);
                    MinionNode minionNode = TypeIdGenerator.getMinionNodeInsts(minionType);
	                if (UserMe.unlockedMinions[i] && minionNode.parent != null && minionNode.parent.minionType == root)
	                    PlayerMe.availableMinionTypes.Add(minionType);
				}
            }
        }
		
    }
}
