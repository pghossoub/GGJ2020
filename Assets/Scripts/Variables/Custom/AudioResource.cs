using UnityEngine;

namespace Marsheleene.Variables
{
    [CreateAssetMenu(menuName = "Variables/Audio")]
    public class AudioResource : ScriptableObject
    {
        public string m_name;
        public AudioClip m_audioClip;
    }
}