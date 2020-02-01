#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomPropertyDrawer(typeof(Vector3Reference))]
    public class Vector3ReferenceDrawer : SingleValueReferenceDrawer { }
}
#endif