#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

namespace Marsheleene.Variables
{
    public class GenericListEditor<T> : Editor
    {
        protected ReorderableList _list;
        protected SerializedProperty _serializedList;

        protected GenericList<T> _genericList
        {
            get
            {
                return target as GenericList<T>;
            }
        }

        protected void OnEnable()
        {
            _serializedList = serializedObject.FindProperty("m_list");
            _list = new ReorderableList(serializedObject, _serializedList, true, true, true, true);

            _list.drawHeaderCallback += DrawHeader;
            _list.drawElementCallback += DrawElement;
            _list.elementHeightCallback += ElementHeight;

            _list.onAddCallback += AddItem;
            _list.onRemoveCallback += RemoveItem;
        }

        protected void OnDisable()
        {
            _list.drawHeaderCallback -= DrawHeader;
            _list.drawElementCallback -= DrawElement;
            _list.elementHeightCallback -= ElementHeight;

            _list.onAddCallback -= AddItem;
            _list.onRemoveCallback -= RemoveItem;
        }

        private void DrawHeader(Rect rect)
        {
            int length = _serializedList.FindPropertyRelative("Array.size").intValue;
            string elementLength = $"{length} element{(length > 0 ? "s" : "")}";
            GUI.Label(rect, "Objects (" + elementLength + ")");
        }

        private void DrawElement(Rect rect, int index, bool active, bool focused)
        {
            EditorGUI.PropertyField(rect, _serializedList.GetArrayElementAtIndex(index), GUIContent.none);
        }

        private float ElementHeight(int index)
        {
            return EditorGUI.GetPropertyHeight(_serializedList.GetArrayElementAtIndex(index));
        }

        private void AddItem(ReorderableList list)
        {
            _genericList.m_list.Add(default);

            EditorUtility.SetDirty(target);
        }

        private void RemoveItem(ReorderableList list)
        {
            _genericList.m_list.RemoveAt(list.index);

            EditorUtility.SetDirty(target);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.Separator();

            _list.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif