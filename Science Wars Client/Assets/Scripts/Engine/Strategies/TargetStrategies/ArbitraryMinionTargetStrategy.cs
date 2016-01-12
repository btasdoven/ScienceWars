using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Towers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Engine.Strategies.TargetStrategies
{
    class ArbitraryMinionTargetStrategy : ITargetStrategy
    {
        public Collection<Minion> selectTargetsFromBoard(Board board, Vector3 selectionPoint, int targetCount, float minRange, float maxRange, MinionStateSelection minionState)
        {
            Collection<Minion> minionsInRange = new Collection<Minion>();
            Collection<Minion> minionsUnderAttack = new Collection<Minion>();

            foreach (var v in board.minions)
            {
                if (targetCount == minionsInRange.Count)    // istenilen miktara ulasmissak return et.
                    return minionsInRange;

                if (v.Value.destroyable == true || (minionState != MinionStateSelection.ANY && ((v.Value.minionState == Minion.MinionState.DEAD && minionState == MinionStateSelection.ALIVE)
                     || (v.Value.minionState == Minion.MinionState.ALIVE && minionState == MinionStateSelection.DEAD))))
                    continue;

                Vector3 minionCoor = v.Value.getWorldPosition();
                float dist = (selectionPoint - minionCoor).magnitude;

                if (v.Value.isUntargetable() == false && dist >= minRange && dist <= maxRange)      // hedef istenilen range'de mi?
                    minionsInRange.Add(v.Value);
            }

            return minionsInRange; // bu kadar bulabildim napalim.
        }


        public Collection<Minion> selectTargetsFromGame(Vector3 selectionPoint, int targetCount, float minRange, float maxRange, MinionStateSelection minionState)
        {
            Collection<Minion> minionsInRange = new Collection<Minion>();

            foreach ( var player in Game.players)
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
