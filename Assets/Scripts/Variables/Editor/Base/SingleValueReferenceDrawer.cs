#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Marsheleene.Variables
{
    public class SingleValueReferenceDrawer : PropertyDrawer
    {
        /// <summary>
        /// Options to display in the popup to select constant or variable.
        /// </summary>
        private readonly string[] popupOptions =
            { "Use Constant", "Use Variable" };

        /// <summary> Cached style to use to draw the popup button. </summary>
        private GUIStyle _popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (_popupStyle == null)
            {
                _popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                _popupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();

            // Get properties
            SerializedProperty useConstant = property.FindPropertyRelative("_useConstant");
            SerializedProperty constantValue = property.FindPropertyRelative("_constantValue");
            SerializedProperty variable = property.FindPropertyRelative("Variable");

            // Calculate rect for configuration button
            Rect buttonRect = new Rect(position);
            buttonRect.yMin += _popupStyle.margin.top;
            buttonRect.width = _popupStyle.fixedWidth + _popupStyle.margin.right;
            position.xMin = buttonRect.xMax + _popupStyle.fixedWidth;

            // Store old indent level and set it to 0, the PrefixLabel takes care of it
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, popupOptions, _popupStyle);

            useConstant.boolValue = result == 0;

            EditorGUI.PropertyField(position,
                useConstant.boolValue ? constantValue : variable,
                GUIContent.none);

            if (EditorGUI.EndChangeCheck())
            {
                property.serializedObject.ApplyModifiedProperties();
            }

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float totalHeight = EditorGUI.GetPropertyHeight(property, label, true);

            if (!property.FindPropertyRelative("_useConstant").boolValue)
            {
                SerializedProperty variable = property.FindPropertyRelative("Variable");
                totalHeight = EditorGUI.GetPropertyHeight(variable, label, true);
            }

            return totalHeight;
        }
    }
}
#endif