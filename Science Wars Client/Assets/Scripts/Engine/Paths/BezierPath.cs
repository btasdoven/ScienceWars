using System;
using Assets.Scripts.Engine.Helpers;
using Assets.Scripts.Engine.GameUtilities;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Engine.Paths
{
    /// <summary>
    /// Bezier Path class to represent paths as a list of bezier curves.
    /// </summary>
    public class BezierPath : IPath
    {
        private List<Vector3> controlPoints;
        
        /// <summary>
        /// constructs a new empty Bezier curve.
        /// </summary>
        public BezierPath()
        {
            controlPoints = new List<Vector3>();
        }

        public BezierPath(List<Vector3> controlPoints)
        {
            this.controlPoints = controlPoints;
        }

        /// <summary>
        /// Sets the control points of this Bezier path.
        /// Points 0-3 forms the first Bezier curve, points 
        /// 3-6 forms the second curve, etc.
        /// </summary>
        /// <param name="newControlPoints">Controls points of bezier curves of the path</param>
        public void SetControlPoints(List<Vector3> newControlPoints)
        {
            controlPoints = newControlPoints;            
        }

        /// <summary>
        /// Getter of control points of this bezier path.
        /// </summary>
        /// <returns>List of Vector3 control points in this bezier path.</returns>
        public List<Vector3> GetControlPoints()
        {
            return controlPoints;
        }

        /// <summary>
        /// Calculates a point on the BezierPath
        /// </summary>
        /// <param name="curveIndex">On which bezier curve, your point is ? (Starts from 0)</param>
        /// <param name="t">between 0 and 1 , specifies the point on the curve</param>
        /// <returns>A Vector3 of the specified point</returns>
        public Vector3 getLocalPosition(PathPosition position)
        {
            int nodeIndex = position.pointIndex;

            Vector3 p0 = controlPoints[nodeIndex];
            Vector3 p1 = controlPoints[nodeIndex + 1];
            Vector3 p2 = controlPoints[nodeIndex + 2];
            Vector3 p3 = controlPoints[nodeIndex + 3];

            return CalculateBezierPoint(position.ratio, p0, p1, p2, p3);
        }

        /// <summary>
        /// Calculates a point on the BezierPath specified with a t and 4 control points.
        /// </summary>
        /// <param name="t">between 0 and 1 , specifies the point on the curve</param>
        /// <param name="p0">Start point of the curve</param>
        /// <param name="p1">Tangent point at the start point</param>
        /// <param name="p2">Tangent point at the end point</param>
        /// <param name="p3">End point of the curve</param>
        /// <returns>A Vector3 of the specified point</returns>
        private Vector3 CalculateBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            float u = 1 - t;
            float tt = t * t;         // t^2
            float uu = u * u;         // (1-t) ^ 2
            float uuu = uu * u;       // (1-t) ^ 3 
            float ttt = tt * t;       // t^3

            Vector3 p = uuu * p0; //first term  (1-t)^3 * p0
            p += 3 * uu * t * p1; //second term (3t^3 - 6t^2 + 3t) * p1
            p += 3 * u * tt * p2; //third term  (-3t^3 + 3t^2) * p2
            p += ttt * p3; //fourth term t^3 * p3

            return p;
        }

        public int getPointCount()
        {
            return controlPoints.Count;
        }

        public PathPosition getStartPoint()
        {
            PathPosition startPoint = new PathPosition(0, 0.0f);
            return startPoint;
        }

        public PathPosition getEndPoint()
        {
            PathPosition endPoint = new PathPosition(controlPoints.Count - 4, 1.0f);
            return endPoint;
        }

        public Vector3 getWorldPosition(MinionPosition minionPosition)
        {
            Board board = minionPosition.board;
            Vector3 point = getLocalPosition(minionPosition.pathPosition);

            float posX = point.x * Mathf.Cos(Mathf.Deg2Rad * board.rotation.y*-1) - point.z * Mathf.Sin(Mathf.Deg2Rad * board.rotation.y*-1);
            float posZ = point.x * Mathf.Sin(Mathf.Deg2Rad * board.rotation.y*-1) + point.z * Mathf.Cos(Mathf.Deg2Rad * board.rotation.y*-1);
            
            return new Vector3(posX, point.y, posZ) + board.position;
        }

        public float move(PathPosition currentPosition, float distance, out PathPosition newPosition)
        {
            newPosition = new PathPosition(currentPosition.pointIndex, currentPosition.ratio);

			float diff = findDiffOnPath(currentPosition).magnitude;
            float bitDistance = distance / diff;

            newPosition.ratio += bitDistance;

            while (newPosition.ratio >= 1)
            {
                newPosition.ratio -= 1;
                newPosition.pointIndex += 3;

                if (newPosition.pointIndex == controlPoints.Count - 1)
                {
                    float remaining = newPosition.ratio * diff;
                    newPosition.pointIndex -= 3;
                    newPosition.ratio = 1;
                    return remaining;
                }
            }

            while (newPosition.ratio < 0)
            {
                newPosition.ratio += 1;
                newPosition.pointIndex -= 3;

                if (newPosition.pointIndex == -3)
                {
                    float remaining = (newPosition.ratio - 1f) * diff;
                    newPosition.pointIndex += 3;
                    newPosition.ratio = 0;
                    return remaining;
                }
				if( newPosition.pointIndex == -4)
				{
					return 0f;
				}
            }
            return 0;
        }

        public Vector3 findDiffOnPath(PathPosition position)
        {
            int index = position.pointIndex;
            Vector3 x = controlPoints[index];
            Vector3 y = controlPoints[index + 1];
            Vector3 z = controlPoints[index + 2];
            Vector3 w = controlPoints[index + 3];

            float t = position.ratio;
            return t * t * (-3 * x + 9 * y - 9 * z + 3 * w) + t * (6 * x - 12 * y + 6 * z) + (-3 * x + 3 * y);
        }

    }
}