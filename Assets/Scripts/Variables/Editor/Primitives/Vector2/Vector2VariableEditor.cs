#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomEditor(typeof(Vector2Variable))]
    public class Vector2VariableEditor : SingleValueVariableEditor<Vector2Variable, Vector2> { }
}
#endif