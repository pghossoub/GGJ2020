#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

using Marsheleene.Tools;

namespace Marsheleene.Variables
{
    public class SingleValueVariableEditor<T, U> : ScriptableObjectEditor<T> where T : SingleValueVariable<U>
    {
        private SerializedProperty _valueProperty;

        protected override void OnEnable()
        {
            base.OnEnable();
            _valueProperty = serializedObject.FindProperty("Value");
        }

        protected override bool HasValueChanged(T obj)
        {
            var value = obj.Value;
            if (!value.Equals(_oldValue))
            {
                _oldValue = value;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void DrawPropertyEditor()
        {
            EditorGUIUtility.labelWidth = 60;

            EditorGUILayout.PropertyField(_valueProperty, new GUIContent("Value"));
        }

        private U _oldValue;
    }
}
#endif