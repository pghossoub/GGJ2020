#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomEditor(typeof(BoolVariable))]
    public class BoolVariableEditor : SingleValueVariableEditor<BoolVariable, bool> { }
}
#endif