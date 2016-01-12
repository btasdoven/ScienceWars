using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Science_Wars_Server.Minions.Biology
{
    class ImmortalStarfishMinion_FastLoyal : ImmortalStarfishMinion_Loyal
    {
        public ImmortalStarfishMinion_FastLoyal(Game game, Player ownerPlayer)
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
                ImmortalStarfishChildMinion_Fast child = new ImmortalStarfishChildMinion_Fast(position.board.player.game, ownerPlayer);
                position.board.AddMinionSpecificPosition(child, position.pathPosition, false);
                child.moveCustomDistance(0.2f * (i - 3));
                // burada bir sikinti var. minion kopyalanmadan pozisyon degistirme bilgisi gonderiliyor client'e. Client da ignore;luyor.
                Messages.OutgoingMessages.Game.GCopyMinionResult.sendMessage(position.board.player.game.players, child);

            }

        }
    }
}
