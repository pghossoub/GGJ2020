using UnityEngine;

namespace Marsheleene.Events
{
    public class AudioResourceEventListener : GameEventListener<AudioResourceEventData>
    {
        [SerializeField]
        private AudioResourceEvent _event = default;

        [SerializeField]
        private AudioResourceCallback _callback = default;

        public override GameEvent<AudioResourceEventData> Event()
        {
            return _event;
        }

        public override GameEventCallback<AudioResourceEventData> Callback()
        {
            return _callback;
        }
    }
}