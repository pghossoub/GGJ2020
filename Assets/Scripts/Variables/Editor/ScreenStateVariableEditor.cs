#if UNITY_EDITOR
using UnityEditor;

using Marsheleene.Variables;

[CustomEditor(typeof(ScreenStateVariable))]
public class ScreenStateVariableEditor : SingleValueVariableEditor<ScreenStateVariable, ScreenState> { }
#endif