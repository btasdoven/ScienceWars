using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions.Biology
{
    class ImmortalStarfishMinion_Loyal : ImmortalStarfishMinion
    {
        public ImmortalStarfishMinion_Loyal(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            
        }

        public override int getUpgradeCost()
        {
            return getCost() * 2;
        }

        public override void spawnChilds()
        {
            for (int i = 0; i < 5; i++)
            {
                ImmortalStarfishChildMinion_Durable child = new ImmortalStarfishChildMinion_Durable(position.board.player.game, ownerPlayer);
                position.board.AddMinionSpecificPosition(child, position.pathPosition, false);
                child.moveCustomDistance(0.2f * (i - 3));
                // burada bir sikinti var. minion kopyalanmadan pozisyon degistirme bilgisi gonderiliyor client'e. Client da ignore;luyor.
                Messages.OutgoingMessages.Game.GCopyMinionResult.sendMessage(position.board.player.game.players, child);

            }
        }

    }
}
