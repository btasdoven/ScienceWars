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
    class MinHealthTargetStrategy : ITargetStrategy
    {
        public Collection<Minion> selectTargetsFromBoard(Board board, Vector3 selectionPoint, int targetCount, float minRange, float maxRange, MinionStateSelection minionState)
        {
            Collection<Minion> minionsInRange = new Collection<Minion>();
            Collection<Minion> minionsUnderAttack = new Collection<Minion>();

            foreach (var v in board.minions)
            {
                if (v.Value.destroyable == true || (minionState != MinionStateSelection.ANY && ((v.Value.minionState == Minion.MinionState.DEAD && minionState == MinionStateSelection.ALIVE)
                     || (v.Value.minionState == Minion.MinionState.ALIVE && minionState == MinionStateSelection.DEAD))))
                    continue;

                Vector3 minionCoor = v.Value.getWorldPosition();
                float dist = (selectionPoint - minionCoor).magnitude;

                if (v.Value.isUntargetable() == false && dist > minRange && dist < maxRange)
                    minionsInRange.Add(v.Value);

            }

            if (targetCount > minionsInRange.Count)
                return minionsInRange;

            for (int i = 0; i < targetCount; i++)
            {
                if (minionsInRange.Count > 0)
                {
                    float current = float.MaxValue;
                    int index = -1;

                    for (int j = 0; j < minionsInRange.Count; j++)
                        if (minionsInRange.ElementAt(j).stats.health < current)
                        {
                            index = j;
                            current = minionsInRange.ElementAt(i).stats.health;
                        }

                    if (index != -1)
                    {
                        minionsUnderAttack.Add(minionsInRange.ElementAt(index));
                        minionsInRange.RemoveAt(index);
                    }
                }
                else
                    return minionsUnderAttack;
            }

            return minionsUnderAttack;
        }


        public Collection<Minion> selectTargetsFromGame(Vector3 selectionPoint, int targetCount, float minRange, float maxRange, MinionStateSelection minionState)
        {
            Collection<Minion> minionsInRange = new Collection<Minion>();
            Collection<Minion> minionsUnderAttack = new Collection<Minion>();

            foreach (var player in Game.players)
                foreach (var v in player.board.minions)
                {
                    if (v.Value.destroyable == true || (minionState != MinionStateSelection.ANY && ((v.Value.minionState == Minion.MinionState.DEAD && minionState == MinionStateSelection.ALIVE)
                         || (v.Value.minionState == Minion.MinionState.ALIVE && minionState == MinionStateSelection.DEAD))))
                        continue;

                    Vector3 minionCoor = v.Value.getWorldPosition();
                    float dist = (selectionPoint - minionCoor).magnitude;

                    if (v.Value.isUntargetable() == false && dist > minRange && dist < maxRange)
                        minionsInRange.Add(v.Value);

                }

            if (targetCount > minionsInRange.Count)
                return minionsInRange;

            for (int i = 0; i < targetCount; i++)
            {
                if (minionsInRange.Count > 0)
                {
                    float current = float.MaxValue;
                    int index = -1;

                    for (int j = 0; j < minionsInRange.Count; j++)
                        if (minionsInRange.ElementAt(j).stats.health < current)
                        {
                            index = j;
                            current = minionsInRange.ElementAt(i).stats.health;
                        }

                    if (index != -1)
                    {
                        minionsUnderAttack.Add(minionsInRange.ElementAt(index));
                        minionsInRange.RemoveAt(index);
                    }
                }
                else
                    return minionsUnderAttack;
            }

            return minionsUnderAttack;
        }
    }
    
}
