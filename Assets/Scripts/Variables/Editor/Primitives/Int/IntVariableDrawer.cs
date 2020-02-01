#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomPropertyDrawer(typeof(IntVariable))]
    public class IntVariableDrawer : SingleValueVariableDrawer<IntVariable, int> { }
}
#endif