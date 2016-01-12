using System;
using NetWorker.Utilities;
using Science_Wars_Server.Boards;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Minions;
using Science_Wars_Server.ScienceTrees.ScienceNodes;
using Science_Wars_Server.ScienceTrees;
using Science_Wars_Server.Statistics;

namespace Science_Wars_Server.Messages.IncomingMessages.Lobby
{
    class GCreateMinionRequest : IncomingMessageImp
    {
        public override void processMessage(RawMessage message, User user)
        {
            if (user.player != null && user.player.playerState != Player.PlayerState.DEAD &&        // adam oyunda mi, ölü mü
                user.player.game.gameState == Science_Wars_Server.Game.GameState.PLAYTIME &&        // oyun pause olmamis ya da bitmemis degil mi?
                user.player.board.nextBoard.boardState != Board.BoardState.COLLAPSING)              // onumuzdeki board çöküyor mu?
            {
                int typeId = message.getInt("tid");

                if (typeId < 0 || typeId >= user.unlockedMinions.Length)
                    return;

                if (user.player.availableMinions[typeId] == false)  // bu availableMinions zaten sadece o scienceType a ait minionlara true iceriyor. Bir daha science type kontrolu yapmaya gerek yok
                    return;

                Minion minion = (Minion) Activator.CreateInstance(TypeIdGenerator.getMinionType(typeId),user.player.game, user.player);

                if (user.player.trySpendCash(minion.getCost()))
                {

                    // STATCODE
                    PlayerStats pStats = user.player.game.statTracker.getPlayerStatsOfPlayer(user.player);
                    pStats.minionsSend += 1;

                    user.player.addIncome(minion.getIncome());
                    user.player.board.nextBoard.AddMinion(minion);
                    OutgoingMessages.Game.GCreateMinionResult.sendMessage(user.player.game.players, minion);
                }

            }

        }

    }
}
