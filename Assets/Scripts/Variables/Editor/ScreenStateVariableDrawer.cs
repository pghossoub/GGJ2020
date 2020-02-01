#if UNITY_EDITOR
using UnityEditor;

using Marsheleene.Variables;

[CustomPropertyDrawer(typeof(ScreenStateVariable))]
public class ScreenStateVariableDrawer : SingleValueVariableDrawer<ScreenStateVariable, ScreenState> { }
#endif