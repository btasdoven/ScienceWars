using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;

namespace Science_Wars_Server.Paths
{
    public interface IPath
    {
        PathPosition getStartPoint();
        PathPosition getEndPoint();
        Vector3 getLocalPosition(PathPosition pathPosition);
        Vector3 getWorldPosition(MinionPosition minionPosition);
        float move(PathPosition currentPosition, float distance, out PathPosition newPosition); // return degeri kalan yurunecek distance i gosterir.
    }
}
