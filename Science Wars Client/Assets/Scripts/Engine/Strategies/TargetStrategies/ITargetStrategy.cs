using System.Collections.ObjectModel;
using Assets.Scripts.Engine.Minions;
using Assets.Scripts.Engine.Towers;
using UnityEngine;

namespace Assets.Scripts.Engine.Strategies.TargetStrategies
{
    public enum MinionStateSelection { DEAD, ALIVE, ANY };
    public interface ITargetStrategy
    {
        /// <summary>
        /// Verilen board uzerindeki minionlardan verilen mesafedekileri secer
        /// </summary>        
        /// <param name="targetCount">Kac adet hedefin secilecegini gosterir (Ornegin, 3'lu fuze atan kule icin gerekli)</param>
        /// <returns>Secilen minionlari return eder</returns>
        Collection<Minion> selectTargetsFromBoard(Board board, Vector3 selectionPoint, int targetCount, float minRange, float maxRange, MinionStateSelection state);
        Collection<Minion> selectTargetsFromGame(Vector3 selectionPoint, int targetCount, float minRange, float maxRange, MinionStateSelection state);
    }
}
