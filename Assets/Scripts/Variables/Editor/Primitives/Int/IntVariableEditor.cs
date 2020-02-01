#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomEditor(typeof(IntVariable))]
    public class IntVariableEditor : SingleValueVariableEditor<IntVariable, int> { }
}
#endif