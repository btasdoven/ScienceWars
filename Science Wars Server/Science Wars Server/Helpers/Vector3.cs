using System;

namespace Science_Wars_Server.Helpers
{
    public class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public Vector3(float _x, float _y, float _z)
        {
            this.x = _x;
            this.y = _y;
            this.z = _z;
        }

        public Vector3(Vector3 v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }

        /// <summary>
        /// returns lenght of vector
        /// </summary>
        /// <returns></returns>
        public float magnitude
        {
            get
            {
                return (float) Math.Sqrt(this.x*this.x + this.y*this.y + this.z*this.z);
            }
        }

        /// <summary>
        /// makes vector a unit vector
        /// </summary>
        public void normalize()
        { 
            float d = this.magnitude;
            this.x = this.x / d;
            this.y = this.y / d;
            this.z = this.z / d;
        }

        /// <summary>
        /// makes vector a unit vector
        /// </summary>
        public Vector3 normalized
        {
            get
            {
                float d = this.magnitude;
                return new Vector3(x/d, y/d,z/d);
            }
        }
    

        /// <summary>
        /// returns dot product of first and second arguments of method
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static float dotProduct(Vector3 v1, Vector3 v2)
        {
            return (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
        }

        /// <summary>
        /// returns dot product of this vector and argument of method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public float dotProduct(Vector3 other)
        {
            return dotProduct(this, other);
        }

        /// <summary>
        /// returns cross product of first and second arguments of method
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Vector3 crossProduct(Vector3 v1, Vector3 v2)
        {
            return new Vector3((v1.y * v2.z) - (v2.y * v1.z),
                               (v1.z * v2.x) - (v2.z * v1.x),
                               (v1.x * v2.y) - (v2.x * v1.y));
        }

        /// <summary>
        /// returns cross product of this vector and argument of method
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vector3 crossProduct(Vector3 other)
        {
            return crossProduct(this, other);
        }


        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3 operator -(Vector3 v1)
        {
            return new Vector3(-v1.x, -v1.y, -v1.z);
        }

        public static bool operator <(Vector3 v1, Vector3 v2)
        {
            return v1.magnitude < v2.magnitude;
        }

        public static bool operator >(Vector3 v1, Vector3 v2)
        {
            return v1.magnitude > v2.magnitude;
        }

        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            return (v1.x == v2.x) && (v1.y == v2.y) && (v1.z == v2.z);
        }

        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return !(v1 == v2);
        }

        public static Vector3 operator /(Vector3 v1, float s2)
        {
            return new Vector3(v1.x / s2, v1.y / s2, v1.z / s2);
        }

        public static Vector3 operator *(Vector3 v1, float s2)
        {
            return new Vector3(v1.x * s2, v1.y * s2, v1.z * s2);
        }

        public static Vector3 operator *(float s1, Vector3 v2)
        {
            return v2 * s1;
        }
    }
}
