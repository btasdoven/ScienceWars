using System.Collections.ObjectModel;
using Science_Wars_Server.Minions;
using Science_Wars_Server.Towers;
using Science_Wars_Server.Boards;
using Science_Wars_Server.Helpers;

namespace Science_Wars_Server.Strategies.TargetStrategies
{
    public enum MinionStateSelection { DEAD, ALIVE, ANY };
    public interface ITargetStrategy
    {
        /// <summary>
        /// verilen kulenin menzilindeki minionlar icerisinden kendi kuralina gore secim yapar.
        /// </summary>
        /// <param name="tower">minionlari secmek icin board ve menzil bilgilerinin alinacagi kule.</param>
        /// <param name="targetCount">Kac adet hedefin secilecegini gosterir (Ornegin, 3'lu fuze atan kule icin gerekli)</param>
        /// <returns>Secilen minionlari return eder</returns>
        Collection<Minion> selectTargetsFromBoard(Board board, Vector3 selectionPoint, int targetCount, float minRange, float maxRange, MinionStateSelection state);
        Collection<Minion> selectTargetsFromGame(Game game, Vector3 selectionPoint, int targetCount, float minRange, float maxRange, MinionStateSelection state);
    }
}
