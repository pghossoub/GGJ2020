using UnityEngine;

namespace Marsheleene.Extensions
{
    public static class Vector3Extensions
    {
        public static float m_floatTolerance = 0.01f;

        public static bool EqualsApprox(this Vector3 me, Vector3 other)
        {
            return me.x.EqualsApprox(other.x) && me.y.EqualsApprox(other.y) && me.z.EqualsApprox(other.z);
        }

        public static bool EqualsApprox(this Vector3 me, Vector3 other, float tolerance)
        {
            return me.x.EqualsApprox(other.x, tolerance) && me.y.EqualsApprox(other.y, tolerance) && me.z.EqualsApprox(other.z, tolerance);
        }

        public static Vector3 zero = new Vector3(0, 0, 0);
        public static Vector3 one = new Vector3(1, 1, 1);
    }
}