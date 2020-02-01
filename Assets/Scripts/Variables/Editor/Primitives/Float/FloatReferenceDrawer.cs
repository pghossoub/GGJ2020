#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomPropertyDrawer(typeof(FloatReference))]
    public class FloatReferenceDrawer : SingleValueReferenceDrawer { }
}
#endif