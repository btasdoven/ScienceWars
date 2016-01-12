using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Messages.IncomingMessages.Lobby
{
    class GUpgradeTowerRequest : IncomingMessageImp
    {
        public override void processMessage(NetWorker.Utilities.RawMessage message, User user)
        {
            if (user.player != null && user.player.playerState == Player.PlayerState.ALIVE &&   // player hayatta mi
                (user.player.game.gameState == Science_Wars_Server.Game.GameState.PLAYTIME ||   // oyun playtime da mi
                user.player.game.gameState == Science_Wars_Server.Game.GameState.STARTCOUNTDOWN))// oyun startcountdownda mi
            {
                int newTowerTypeId = message.getInt("tid");
                int indexOnBoard = message.getInt("iob");

                if( newTowerTypeId < 0 || user.unlockedTowers.Length < newTowerTypeId)  //typeId valid?
                    return;
                if (indexOnBoard < 0 || indexOnBoard > user.player.board.towers.Length - 1)  // indexOnBoard valid?
                    return;

                Tower oldTower = user.player.board.towers[indexOnBoard];
                if ( oldTower == null) // upgrade edilmek istenen noktada bir kule var mi. ( havayi mi upgrade edeceksin essoglu essek )
                    return;
                
                if (checkIfTowerUpgradableTo( TypeIdGenerator.getTowerId(oldTower.GetType()), TypeIdGenerator.getTowerType(newTowerTypeId) ) == false) // bu kule, istenen turdeki kuleye upgrade edilebilir mi?
                    return;

                if ( user.unlockedTowers[newTowerTypeId] == true )// bu kule unlocklanmis mi?
                {
                    Tower tower =
                        (Tower)
                            Activator.CreateInstance(TypeIdGenerator.getTowerType(newTowerTypeId), user.player.board,
                                indexOnBoard);

                    if (user.player.trySpendCash(tower.getCost()) && user.player.board.AddTower(tower, indexOnBoard))
                    {
                        OutgoingMessages.Game.GUpgradeTowerResult.sendMessage(user.player.game.players, tower, newTowerTypeId);
                        OutgoingMessages.Game.GCashAndIncomeInfo.sendMessage(user.player);
                    }
                }
            }
        }

        private bool checkIfTowerUpgradableTo(int currentTowerTypeId, Type upgradingTowerType)
        {
            TowerNode tn = TypeIdGenerator.getTowerNodeInst(upgradingTowerType);
            
            if (tn == null)
                return false;

            return tn.checkParent( currentTowerTypeId ) != null ;
        }
    }
}
