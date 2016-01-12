using Assets.Scripts.Engine.GameUtilities;
using Assets.Scripts.Engine.Helpers;
using UnityEngine;

namespace Assets.Scripts.Engine.Paths
{
    public interface IPath
    {
        int getPointCount();
        PathPosition getStartPoint();
        PathPosition getEndPoint();
		Vector3 getLocalPosition(PathPosition pathPosition);
        Vector3 getWorldPosition(MinionPosition minionPosition);
		Vector3 findDiffOnPath(PathPosition position);
        float move(PathPosition currentPosition, float distance, out PathPosition newPosition); // return degeri kalan yurunecek distance i gosterir.
    }
}
