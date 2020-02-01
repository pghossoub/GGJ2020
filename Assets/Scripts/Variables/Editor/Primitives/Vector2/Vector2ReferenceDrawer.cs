#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomPropertyDrawer(typeof(Vector2Reference))]
    public class Vector2ReferenceDrawer : SingleValueReferenceDrawer { }
}
#endif