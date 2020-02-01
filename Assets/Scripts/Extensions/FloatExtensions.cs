using UnityEngine;

namespace Marsheleene.Extensions
{
    public static class FloatExtensions
    {
        public static float m_floatTolerance = 0.01f;

        public static bool EqualsApprox(this float me, float other)
        {
            return Mathf.Abs(me - other) < m_floatTolerance;
        }

        public static bool EqualsApprox(this float me, float other, float tolerance)
        {
            return Mathf.Abs(me - other) < tolerance;
        }
    }
}