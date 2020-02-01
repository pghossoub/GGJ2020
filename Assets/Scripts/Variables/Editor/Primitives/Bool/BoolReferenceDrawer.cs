#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomPropertyDrawer(typeof(BoolReference))]
    public class BoolReferenceDrawer : SingleValueReferenceDrawer { }
}
#endif