#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomPropertyDrawer(typeof(StringVariable))]
    public class StringVariableDrawer : SingleValueVariableDrawer<StringVariable, string> { }
}
#endif