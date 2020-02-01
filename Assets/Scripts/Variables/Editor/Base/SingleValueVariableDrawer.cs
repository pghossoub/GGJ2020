#if UNITY_EDITOR
using UnityEngine;

using Marsheleene.Tools;
using UnityEditor;

namespace Marsheleene.Variables
{
    public class SingleValueVariableDrawer<T, U> : ScriptableObjectDrawer<T> where T : SingleValueVariable<U>
    {
        protected override void DrawProperty(Rect position, SerializedProperty property)
        {
            SerializedProperty valueProperty = _serializedObject.FindProperty("Value");
            Rect rect = new Rect(position);
            EditorGUI.PropertyField(rect, valueProperty, new GUIContent("Value"));
        }

        protected override float GetPropertyHeight(SerializedProperty property)
        {
            return EditorTools.SINGLE_LINE_HEIGHT;
        }
    }
}
#endif