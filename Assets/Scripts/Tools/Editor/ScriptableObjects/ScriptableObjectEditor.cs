#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace Marsheleene.Tools
{
    public abstract class ScriptableObjectEditor<T> : Editor where T : ScriptableObject
    {
        #region System

        protected virtual void OnEnable()
        {
            _obj = serializedObject;
            _object = (T)target;
            _scriptProperty = serializedObject.FindProperty("m_Script");
            EditorApplication.update += Update;
        }

        protected virtual void OnDisable()
        {
            EditorApplication.update -= Update;
        }

        private void Update()
        {
            if (!HasValueChanged(_object))
            {
                return;
            }
            Repaint();
        }

        #endregion


        #region Main

        public override void OnInspectorGUI()
        {
            _obj.Update();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            EditorGUILayout.LabelField(typeof(T).Name + " : " + _object.name, EditorTools.STYLE_CENTER_ALIGN_BOLD);

            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.PropertyField(_scriptProperty, new GUIContent("Script"));
            EditorGUI.EndDisabledGroup();

            EditorGUILayout.Space();

            DrawPropertyEditor();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            _obj.ApplyModifiedProperties();
        }

        #endregion


        #region Private & protected

        protected abstract bool HasValueChanged(T obj);
        protected abstract void DrawPropertyEditor();

        protected SerializedObject _obj;
        protected T _object;
        protected SerializedProperty _scriptProperty;

        #endregion
    }
}
#endif