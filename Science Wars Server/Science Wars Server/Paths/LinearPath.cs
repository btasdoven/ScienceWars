using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Science_Wars_Server.Boards;
using Science_Wars_Server.GameUtilities;
using Science_Wars_Server.Helpers;

namespace Science_Wars_Server.Paths
{
    public class LinearPath : IPath
    {
        private const float Deg2Rad = (float)(Math.PI / 180.0f);

        private Vector3[] points;
        private float distanceBetweenPoints;

        public LinearPath(IPath anotherPath, int sampleCount)
        {
            List<Vector3> pointList = new List<Vector3>(1000);

            PathPosition pathPosition = anotherPath.getStartPoint();

            float pathLength = 0f;
            float remaining = 0f;

            while (remaining == 0)
            {
                remaining = anotherPath.move(pathPosition, 0.01f, out pathPosition);
                pathLength += 0.01f;
            }
            pathLength -= remaining;

            distanceBetweenPoints = pathLength/sampleCount;
            pathPosition = anotherPath.getStartPoint();
            remaining = 0;

            while (remaining == 0f)
            {
                pointList.Add(anotherPath.getLocalPosition(pathPosition));
                remaining = anotherPath.move(pathPosition, distanceBetweenPoints, out pathPosition);
            }

            if (remaining < distanceBetweenPoints/2f)
                pointList[pointList.Count - 1] = anotherPath.getLocalPosition(anotherPath.getEndPoint());
            else
                pointList.Add( anotherPath.getLocalPosition(anotherPath.getEndPoint()));

            points = pointList.ToArray();
        }

        public PathPosition getStartPoint()
        {
            return new PathPosition(0, 0.0f);
        }

        public PathPosition getEndPoint()
        {
            return new PathPosition( points.Count()-2,1.0f);
        }

        public Vector3 getLocalPosition(PathPosition pathPosition)
        {
            return points[pathPosition.pointIndex] + (points[pathPosition.pointIndex+1] - points[pathPosition.pointIndex])*pathPosition.ratio ;
        }

        public Vector3 getWorldPosition(MinionPosition minionPosition)
        {
            Board board = minionPosition.board;
            Vector3 point = getLocalPosition(minionPosition.pathPosition);

            double angle = Deg2Rad*board.rotation.y*-1;
            float sin = (float) Math.Sin(angle);
            float cos = (float) Math.Cos(angle);
            float posX = point.x * cos - point.z * sin;
            float posZ = point.x * sin + point.z * cos;

            return new Vector3(posX, point.y, posZ) + board.position;
        }

        public float move(PathPosition currentPosition, float distance, out PathPosition newPosition)
        {
            float distToEnd = (points.Length-1 - currentPosition.pointIndex - currentPosition.ratio)*distanceBetweenPoints;
            float distToStart = (currentPosition.pointIndex + currentPosition.ratio)*distanceBetweenPoints;

            if ( distance - distToEnd > 0)
            {
                newPosition = getEndPoint();
                return distance - distToEnd;
            }
            else if (distance + distToStart < 0)
            {
                newPosition = getStartPoint();
                return distance + distToStart;
            }

            distance += currentPosition.ratio*distanceBetweenPoints;

            int tam = (int)(distance / distanceBetweenPoints);
            float artan = distance/distanceBetweenPoints - tam;

            if (artan < 0)
            {
                artan += 1f;
                tam--;
            }

            newPosition = new PathPosition( currentPosition.pointIndex + tam, artan);
            return 0;
        }
    }
}
