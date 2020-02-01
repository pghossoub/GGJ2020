#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomPropertyDrawer(typeof(Vector2Variable))]
    public class Vector2VariableDrawer : SingleValueVariableDrawer<Vector2Variable, Vector2> { }
}
#endif