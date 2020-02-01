#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Events
{
    [CustomPropertyDrawer(typeof(AudioResourceEventData))]
    public class AudioResourceEventDataDrawer : SingleValueEventDataDrawer
    {
        public override SerializedProperty GetValueProperty(SerializedProperty property)
        {
            return property.FindPropertyRelative("_value");
        }
    }
}
#endif