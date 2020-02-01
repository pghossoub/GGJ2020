using UnityEngine;

namespace Marsheleene.Extensions
{
    public static class Vector2Extensions
    {
        public static float m_floatTolerance = 0.01f;

        public static bool EqualsApprox(this Vector2? me, Vector2 other)
        {
            return me.EqualsApprox(other, m_floatTolerance);
        }

        public static bool EqualsApprox(this Vector2? me, Vector2 other, float tolerance)
        {
            if (me == null)
            {
                return false;
            }
            else
            {
                return ((Vector2)me).EqualsApprox(other, tolerance);
            }
        }

        public static bool EqualsApprox(this Vector2 me, Vector2? other)
        {
            return me.EqualsApprox(other, m_floatTolerance);
        }

        public static bool EqualsApprox(this Vector2 me, Vector2? other, float tolerance)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return me.EqualsApprox((Vector2)other, tolerance);
            }
        }

        public static bool EqualsApprox(this Vector2? me, Vector2? other, float tolerance)
        {
            if (me == null && other == null)
            {
                return true;
            }
            else if (me != null && other == null)
            {
                return false;
            }
            else if (me == null && other != null)
            {
                return false;
            }
            else
            {
                return ((Vector2)me).EqualsApprox((Vector2)other, tolerance);
            }
        }

        public static bool EqualsApprox(this Vector2? me, Vector2? other)
        {
            return me.EqualsApprox(other, m_floatTolerance);
        }


        public static bool EqualsApprox(this Vector2 me, Vector2 other)
        {
            return me.x.EqualsApprox(other.x) && me.y.EqualsApprox(other.y);
        }

        public static bool EqualsApprox(this Vector2 me, Vector2 other, float tolerance)
        {
            return me.x.EqualsApprox(other.x, tolerance) && me.y.EqualsApprox(other.y, tolerance);
        }

        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            return Quaternion.Euler(0, 0, degrees) * v;
        }

        public static Vector2 zero = new Vector2(0, 0);
        public static Vector2 one = new Vector2(1, 1);
        public static Vector2 up = new Vector2(0, 1);
        public static Vector2 down = new Vector2(0, -1);
        public static Vector2 right = new Vector2(1, 0);
        public static Vector2 left = new Vector2(-1, 0);
    }
}