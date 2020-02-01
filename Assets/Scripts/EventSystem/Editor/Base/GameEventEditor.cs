#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

using Marsheleene.Tools;

namespace Marsheleene.Events
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {
        private SerializedObject _obj;
        private SerializedProperty _valueProp;
        private GameEvent _event;

        private void OnEnable()
        {
            _obj = serializedObject;
            _valueProp = _obj.FindProperty("_eventData");

            _event = target as GameEvent;
        }

        public override void OnInspectorGUI()
        {
            _obj.Update();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            EditorGUILayout.LabelField(typeof(GameEvent).Name + " : " + _event.name, EditorTools.STYLE_CENTER_ALIGN_BOLD);

            EditorGUI.BeginDisabledGroup(!Application.isPlaying);
            if (GUILayout.Button("Raise"))
            {
                _event.Raise(null);
            }
            EditorGUI.EndDisabledGroup();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            _obj.ApplyModifiedProperties();
        }
    }

    public class GameEventEditor<T, U> : Editor
        where T : GameEvent<U>
        where U : GameEventData
    {
        private SerializedObject _obj;
        private SerializedProperty _valueProp;
        private T _event;
        private U _data;

        private void OnEnable()
        {
            _obj = serializedObject;
            _valueProp = _obj.FindProperty("_eventData");

            _event = target as T;
            _data = _event.EventData;
        }

        public override void OnInspectorGUI()
        {
            _obj.Update();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            EditorGUILayout.LabelField(typeof(T).Name + " : " + _event.name, EditorTools.STYLE_CENTER_ALIGN_BOLD);

            EditorGUILayout.BeginVertical(EditorTools.STYLE_BOX);

            EditorGUILayout.LabelField("Event Data", EditorTools.STYLE_BOLD);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(_valueProp, GUIContent.none);

            EditorGUILayout.EndVertical();

            EditorGUI.BeginDisabledGroup(!Application.isPlaying);
            if (GUILayout.Button("Raise"))
            {
                _event.Raise(null, _data);
            }
            EditorGUI.EndDisabledGroup();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            _obj.ApplyModifiedProperties();
        }
    }
}
#endif