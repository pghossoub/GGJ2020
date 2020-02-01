#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Marsheleene.Events
{
    public abstract class SingleValueEventDataDrawer : PropertyDrawer
    {
        public abstract SerializedProperty GetValueProperty(SerializedProperty property);

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);

            SerializedProperty valueProperty = GetValueProperty(property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            position.height = EditorGUIUtility.singleLineHeight;

            EditorGUI.PropertyField(position, valueProperty, GUIContent.none);

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty valueProperty = GetValueProperty(property);
            return EditorGUI.GetPropertyHeight(valueProperty);
        }
    }
}
#endif