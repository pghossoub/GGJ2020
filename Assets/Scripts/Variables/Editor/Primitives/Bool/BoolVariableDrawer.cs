#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Variables
{
    [CustomPropertyDrawer(typeof(BoolVariable))]
    public class BoolVariableDrawer : SingleValueVariableDrawer<BoolVariable, bool> { }
}
#endif