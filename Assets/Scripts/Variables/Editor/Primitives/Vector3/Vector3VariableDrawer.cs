#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomPropertyDrawer(typeof(Vector3Variable))]
    public class Vector3VariableDrawer : SingleValueVariableDrawer<Vector3Variable, Vector3> { }
}
#endif