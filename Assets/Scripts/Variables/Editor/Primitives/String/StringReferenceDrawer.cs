#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomPropertyDrawer(typeof(StringReference))]
    public class StringReferenceDrawer : SingleValueReferenceDrawer { }
}
#endif