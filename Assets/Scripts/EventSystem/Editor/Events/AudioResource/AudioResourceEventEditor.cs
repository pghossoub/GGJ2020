#if UNITY_EDITOR
using UnityEditor;

namespace Marsheleene.Events
{
    [CustomEditor(typeof(AudioResourceEvent))]
    public class AudioResourceEventEditor : GameEventEditor<AudioResourceEvent, AudioResourceEventData> { }
}
#endif