using UnityEngine;
using UnityEngine.Video;

public class VideoFragment : MonoBehaviour
{
    public VideoClip m_clip;

    [Range(0, 10)]
    public int m_order;
}
