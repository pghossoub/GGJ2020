using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AssemblingVideos : MonoBehaviour
{
    public int[] videoOrder;
    public VideoClip[] m_videos;
    private VideoPlayer _video;
    private AudioSource _audio;

    private void Start()
    {
        StartCoroutine("ReadVideos");
    }

    IEnumerator ReadVideos()
    {
        _video = gameObject.GetComponent<VideoPlayer>();
        _audio = gameObject.GetComponent<AudioSource>();

        _video.playOnAwake = false;
        _audio.playOnAwake = false;

        for (int i = 0; i < videoOrder.Length; i++)
        {
            _video.clip = m_videos[videoOrder[i]];
            _video.Play();
            _audio.Play();
            yield return new WaitForSeconds((float)_video.length);
        }
    }
}
