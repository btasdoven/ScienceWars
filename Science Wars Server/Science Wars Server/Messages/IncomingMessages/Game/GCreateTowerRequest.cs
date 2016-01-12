using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Statistics;

namespace Science_Wars_Server.Messages.IncomingMessages.Lobby
{
    class GCreateTowerRequest : IncomingMessageImp
    {
        public override void processMessage(NetWorker.Utilities.RawMessage message, User user)
        {
            if (user.player != null && user.player.playerState == Player.PlayerState.ALIVE &&   // player hayatta mi
                (user.player.game.gameState == Science_Wars_Server.Game.GameState.PLAYTIME ||   // oyun playtime da mi
                user.player.game.gameState == Science_Wars_Server.Game.GameState.STARTCOUNTDOWN))// oyun startcountdownda mi
            {
                int typeId = message.getInt("tid");
                int indexOnBoard = message.getInt("iob");

                if( typeId < 0 || user.unlockedTowers.Length < typeId)  //typeId valid?
                    return;
                if (indexOnBoard < 0 || indexOnBoard > user.player.board.towers.Length - 1)  // indexOnBoard valid?
                    return;

                if (checkScienceTypeOfTower(typeId, user.player.getScienceType()) == false) // player'in oyun basinda sectigi science'a ait bir kule mi bu?
                    return;

                if ( user.unlockedTowers[typeId] == true // bu kule unlocklanmis mi?
                     && user.player.board.towers[indexOnBoard] == null)  // bu slotta baska kule var mi?
                {
                    Tower tower =
                        (Tower)
                            Activator.CreateInstance(TypeIdGenerator.getTowerType(typeId), user.player.board,
                                indexOnBoard);

                    if (user.player.trySpendCash(tower.getCost()) && user.player.board.AddTower(tower, indexOnBoard))
                    {
                        // STATCODE
                        PlayerStats pStats = user.player.game.statTracker.getPlayerStatsOfPlayer(user.player);
                        pStats.towersBuilt += 1;

                        OutgoingMessages.Game.GCreateTowerResult.sendMessage(user.player.game.players, tower);
                        OutgoingMessages.Game.GCashAndIncomeInfo.sendMessage(user.player);
                    }
                }
            }
        }

        private bool checkScienceTypeOfTower(int typeId, ScienceType userScienceType)
        {
            Type root = null;

            switch (userScienceType)
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

            Type type = TypeIdGenerator.getTowerType(typeId);
            TowerNode node = TypeIdGenerator.getTowerNodeInst(type);

            if (node.towerType != root && node.getRoot().towerType == root)
                return true;

            return false;
        }
    }
}
