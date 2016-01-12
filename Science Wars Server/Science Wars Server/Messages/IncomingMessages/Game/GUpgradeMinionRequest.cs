using System;
using NetWorker.Utilities;
using Science_Wars_Server.Boards;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using Science_Wars_Server.ScienceTrees.ScienceNodes;
using Science_Wars_Server.ScienceTrees;

namespace Science_Wars_Server.Messages.IncomingMessages.Lobby
{
    class GUpgradeMinionRequest : IncomingMessageImp
    {
        public override void processMessage(RawMessage message, User user)
        {
            if (user.player != null && user.player.playerState != Player.PlayerState.DEAD &&        // adam oyunda mi, ölü mü
                user.player.game.gameState == Science_Wars_Server.Game.GameState.PLAYTIME &&        // oyun pause olmamis ya da bitmemis degil mi?
                user.player.board.nextBoard.boardState != Board.BoardState.COLLAPSING)              // onumuzdeki board çöküyor mu?
            {
                int oldMinionTypeId = message.getInt("tid");
                int upgradedMinionTypeId = message.getInt("utid");

                if ((oldMinionTypeId < 0 || oldMinionTypeId >= user.player.availableMinions.Length) &&  // verilen typeId'ler mantikli.
                    (upgradedMinionTypeId < 0 || upgradedMinionTypeId >= user.player.availableMinions.Length))
                    return;

                if (user.player.availableMinions[oldMinionTypeId] == false || user.unlockedMinions[upgradedMinionTypeId] == false) // bu minionlar unlocked mi? (dikkat: birinin unlock durumuna bakiyoruz digerinin available durumuna )
                    return;

                if( checkIfMinionUpgradableTo( oldMinionTypeId, TypeIdGenerator.getMinionType(upgradedMinionTypeId) ) == false ) // bu minion verilen miniona upgrade edilebilir mi
                    return;

                Minion minion = (Minion) Activator.CreateInstance(TypeIdGenerator.getMinionType(upgradedMinionTypeId),user.player.game, user.player);   // bir instance olusturuyoruz. tek sebebi upgradeCost u ogrenmek. damn...

                if (user.player.trySpendCash(minion.getUpgradeCost()))
                {
                    user.player.availableMinions[oldMinionTypeId] = false;
                    user.player.availableMinions[upgradedMinionTypeId] = true;
                    OutgoingMessages.Game.GUpgradeMinionResult.sendMessage(user.player, oldMinionTypeId, upgradedMinionTypeId);
                }

            }

        }

        private bool checkIfMinionUpgradableTo(int currentMinionTypeId, Type upgradedMinionType)
        {
            MinionNode tn = TypeIdGenerator.getMinionNodeInst(upgradedMinionType);

            if (tn == null)
                return false;

            return tn.checkParent(currentMinionTypeId) != null;
        }
    }
}
