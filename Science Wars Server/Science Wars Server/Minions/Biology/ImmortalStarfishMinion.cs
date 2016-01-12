using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Boards;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;


namespace Science_Wars_Server.Minions.Biology
{
    class ImmortalStarfishMinion : BiologyMinion
    {
        private static int cost = 2100;
        private static int upgradeCost = 0;
        private static int income = 121;
        private static int killGold = 525;
        private static int healthCost = 5;
     
        public ImmortalStarfishMinion(Game game, Player ownerPlayer)
            : base(game, ownerPlayer)
        {
            // butun initializationlari burada yap. yok efendim can setlemek, yok efendim movementspeed bilmemne.
            stats.healthTotal = stats.health = 650;
            stats.baseMovementSpeed = 0.7f;

            stats.setBaseResistances(new List<DamageResistance>() { new DamageResistance(DamageType.PHYSICAL, .7f) });
        }

        public override int getIncome()
        {
            return income;
        }

        public override int getKillGold()
        {
            return killGold;
        }

        public override int getHealthCost()
        {
            return healthCost;
        }

        public override int getCost()
        {
            return cost;
        }

        public override int getUpgradeCost()
        {
            return upgradeCost;
        }
       
        public virtual void spawnChilds()
        {
            for (int i = 0; i < 5; i++)
            {
                ImmortalStarfishChildMinion child = new ImmortalStarfishChildMinion(position.board.player.game, ownerPlayer);
                position.board.AddMinionSpecificPosition(child, position.pathPosition, false);
                child.moveCustomDistance(0.2f * (i - 3));
                // burada bir sikinti var. minion kopyalanmadan pozisyon degistirme bilgisi gonderiliyor client'e. Client da ignore;luyor.
                Messages.OutgoingMessages.Game.GCopyMinionResult.sendMessage(position.board.player.game.players, child);

            }  
        }

        public override void onDeath()
        {
            base.onDeath();
            spawnChilds();             
        }
    }
}
