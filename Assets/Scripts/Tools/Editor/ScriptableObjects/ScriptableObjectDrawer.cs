#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

using Marsheleene.Extensions;

namespace Marsheleene.Tools
{
    public abstract class ScriptableObjectDrawer<T> : PropertyDrawer where T : ScriptableObject
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);

            Rect rect = new Rect(position);
            rect.height = EditorTools.SINGLE_LINE_HEIGHT;

            rect = EditorGUI.PrefixLabel(rect, label);

            EditorGUI.ObjectField(rect, property, GUIContent.none);

            rect.x = position.x;

            _object = (T)property.GetTargetObject();

            if (_object == null)
            {
                EditorGUI.EndProperty();
                return;
            }

            _serializedObject = new SerializedObject(property.objectReferenceValue);

            property.isExpanded = EditorGUI.Foldout(rect, property.isExpanded, GUIContent.none, true);

            if (!property.isExpanded)
            {
                EditorGUI.EndProperty();
                return;
            }

            Rect backgroundRect = EditorTools.NewLine(position, rect);
            //backgroundRect.yMin += EditorTools.BOX_PADDING_OUTER;

            float propertyHeight = GetPropertyHeight(property);
            backgroundRect.height = propertyHeight + EditorTools.BOX_PADDING_INNER * 2;

            EditorTools.DrawBackground(backgroundRect, EditorTools.BackgroundStyle.HelpBox);

            Rect expandedRect = EditorTools.NewLine(position, rect);
            expandedRect.xMax -= EditorTools.BOX_PADDING_INNER;
            expandedRect.xMin += EditorTools.BOX_PADDING_INNER;
            expandedRect.yMin += EditorTools.BOX_PADDING_INNER;
            expandedRect.yMax += EditorTools.BOX_PADDING_INNER;
            expandedRect.height = EditorTools.SINGLE_LINE_HEIGHT;

            EditorGUI.BeginChangeCheck();
            DrawProperty(expandedRect, property);
            if (EditorGUI.EndChangeCheck())
            {
                _serializedObject.ApplyModifiedProperties();
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float totalHeight = EditorTools.SINGLE_LINE_HEIGHT;

            _object = (T)property.GetTargetObject();

            if (_object != null && property.isExpanded)
            {
                totalHeight += GetPropertyHeight(property);
                totalHeight += EditorTools.BOX_PADDING_INNER * 2 + EditorTools.BOX_PADDING_OUTER;
            }

            return totalHeight;
        }

        protected abstract void DrawProperty(Rect position, SerializedProperty property);
        protected abstract float GetPropertyHeight(SerializedProperty property);

        protected T _object;
        protected SerializedObject _serializedObject;
    }
}
#endif