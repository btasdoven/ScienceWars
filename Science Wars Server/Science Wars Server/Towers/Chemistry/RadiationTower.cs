using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Boards;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Missiles.Chemistry;
using Science_Wars_Server.Strategies.TargetStrategies;
using Science_Wars_Server.AreaEffects;

namespace Science_Wars_Server.Towers.Chemistry
{
    class RadiationTower : ChemistryTower
    {
        private const int cost = 17000;

        private float nextAttackTime = 0;
        private const float ATTACK_COOLDOWN = 0.5f;

        public RadiationTower(Board board, int indexOnBoard)
            : base(board, indexOnBoard)
        {
            // base constructor gerekli board ve index setlemelerini yapiyor. effects ve stats i initialize ediyor.
            stats.baseRange = 3.0f;
        }

        public override void step()
        {
            applyEffects();

            //attackTimeReduction kendi icerisine Chronos.deltaTime'i ekliyor. applyEffects'e bak.
            nextAttackTime -= stats.attackTimeReduction;

            if (nextAttackTime <= 0 && targetStrategy != null && !this.isStunned())
            {
                AreaEffect areaEffect = new RadiationTowerAreaEffect(board.player, this.getWorldPosition());
                board.player.game.addAreaEffect(areaEffect);
                Messages.OutgoingMessages.Game.GAddAreaEffect.sendMessage(board.player.game.players, areaEffect);
                nextAttackTime = ATTACK_COOLDOWN;

            }
        }

        public override int getCost()
        {
            return cost;
        }
    }
}
