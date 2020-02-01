namespace Marsheleene.Extensions
{
    public static class ObjectExtensions
    {
        public static T Ref<T>(this T o) where T : UnityEngine.Object
        {
            return o == null ? null : o;
        }
    }
}