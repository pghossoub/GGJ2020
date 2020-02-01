#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomEditor(typeof(StringVariable))]
    public class StringVariableEditor : SingleValueVariableEditor<StringVariable, string> { }
}
#endif