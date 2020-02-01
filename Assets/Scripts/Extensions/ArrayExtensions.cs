
namespace Marsheleene.Extensions
{
    public static class ArrayExtensions
    {
        public static T Random<T>(T[] me)
        {
            if (me.Length == 0)
            {
                return default(T);
            }

            return me[UnityEngine.Random.Range(0, me.Length)];
        }
    }
}