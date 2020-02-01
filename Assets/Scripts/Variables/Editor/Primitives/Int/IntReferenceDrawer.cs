#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomPropertyDrawer(typeof(IntReference))]
    public class IntReferenceDrawer : SingleValueReferenceDrawer { }
}
#endif