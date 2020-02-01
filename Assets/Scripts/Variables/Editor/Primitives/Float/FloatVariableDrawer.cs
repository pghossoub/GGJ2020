#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomPropertyDrawer(typeof(FloatVariable))]
    public class FloatVariableDrawer : SingleValueVariableDrawer<FloatVariable, float> { }
}
#endif