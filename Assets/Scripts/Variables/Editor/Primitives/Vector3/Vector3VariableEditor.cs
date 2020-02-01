#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomEditor(typeof(Vector3Variable))]
    public class Vector3VariableEditor : SingleValueVariableEditor<Vector3Variable, Vector3> { }
}
#endif