using Science_Wars_Server.Boards;

namespace Science_Wars_Server.GameUtilities
{
    public class MinionPosition
    {
        public PathPosition pathPosition; // suan yurumekte oldugu yolun yuzde kacini yurudugunu tutar.
        public Board board; // suan yurumekte oldugu board

        public MinionPosition()
        {
            pathPosition = new PathPosition(0, 0);
        }
        public MinionPosition clone()
        {
            MinionPosition minPos = new MinionPosition();
            minPos.board = board;
            minPos.pathPosition = pathPosition.clone();
            return minPos;
        }
    }
}
