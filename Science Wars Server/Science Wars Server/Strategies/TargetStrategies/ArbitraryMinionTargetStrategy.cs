using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Towers;
using Science_Wars_Server.Paths;
using Science_Wars_Server.Helpers;
using Science_Wars_Server.Boards;

namespace Science_Wars_Server.Strategies.TargetStrategies
{
    /// <summary>
    /// Diger target strategylere gore cost'u dusuktur. Ancak secim yaparken herhangi bir kriteri dikkate almaz, sirayla secer.
    /// </summary>
    class ArbitraryMinionTargetStrategy : ITargetStrategy
    {
        public Collection<Minion> selectTargetsFromBoard(Board board, Vector3 selectionPoint, int targetCount, float minRange, float maxRange, MinionStateSelection minionState)
        {
            Collection<Minion> minionsInRange = new Collection<Minion>();

            foreach (var v in board.minions)
            {
                if (targetCount == minionsInRange.Count)    // istenilen miktara ulasmissak return et.
                    return minionsInRange;

                if (v.Value.destroyable == true || ( minionState != MinionStateSelection.ANY && ((v.Value.minionState == Minion.MinionState.DEAD && minionState == MinionStateSelection.ALIVE)
                     || (v.Value.minionState == Minion.MinionState.ALIVE && minionState == MinionStateSelection.DEAD))))
                    continue;

                Vector3 minionCoor = v.Value.getWorldPosition();
                float dist = (selectionPoint - minionCoor).magnitude;

                if (v.Value.isUntargetable() == false && dist >= minRange && dist <= maxRange)      // hedef istenilen range'de mi?
                    minionsInRange.Add(v.Value);
            }
                        
            return minionsInRange; // bu kadar bulabildim napalim.
        }


        public Collection<Minion> selectTargetsFromGame(Game game, Vector3 selectionPoint, int targetCount, float minRange, float maxRange, MinionStateSelection minionState)
        {
            Collection<Minion> minionsInRange = new Collection<Minion>();

            foreach (var player in game.players)
                foreach (var v in player.board.minions)
                {
                    if (targetCount == minionsInRange.Count)    // istenilen miktara ulasmissak return et.
                        return minionsInRange;

                    if (v.Value.destroyable == true || (minionState != MinionStateSelection.ANY && ((v.Value.minionState == Minion.MinionState.DEAD && minionState == MinionStateSelection.ALIVE)
                         || (v.Value.minionState == Minion.MinionState.ALIVE && minionState == MinionStateSelection.DEAD))))
                        continue;

                    Vector3 minionCoor = v.Value.getWorldPosition();
                    float dist = (selectionPoint - minionCoor).magnitude;

                    if (v.Value.isUntargetable() == false && dist > minRange && dist < maxRange)
                        minionsInRange.Add(v.Value);
                }
            
            return minionsInRange;
        }
    }

}
