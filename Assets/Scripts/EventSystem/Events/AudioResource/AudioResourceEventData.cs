using UnityEngine;

using Marsheleene.Variables;

namespace Marsheleene.Events
{
    [System.Serializable]
    public class AudioResourceEventData : SingleValueEventData<AudioResource>
    {
        [SerializeField]
        private AudioResource _value;

        public override AudioResource Value { get => _value; set => _value = value; }

        public AudioResourceEventData() : base() { }
        public AudioResourceEventData(AudioResource value) : base(value) { }
    }
}