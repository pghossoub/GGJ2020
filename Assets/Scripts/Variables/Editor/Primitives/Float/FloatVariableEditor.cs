#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomEditor(typeof(FloatVariable))]
    public class FloatVariableEditor : SingleValueVariableEditor<FloatVariable, float> { }
}
#endif