using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AssemblingVideos : MonoBehaviour
{
    public int[] m_videoOrder;
    public VideoClip[] m_videos;
    public Renderer m_ecranAffichage;
    public Material m_videoMaterial;

    private VideoPlayer _videoPlayer;
    private AudioSource _audioSource;

    private void Awake()
    {
        _videoPlayer = gameObject.GetComponent<VideoPlayer>();
        _audioSource = gameObject.GetComponent<AudioSource>();

        _videoPlayer.playOnAwake = false;
        _audioSource.playOnAwake = false;
    }

    private void Start()
    {
        _videoPlayer.targetTexture.Release();
        StartCoroutine("ReadVideos");
    }

    IEnumerator ReadVideos()
    {
        Material originalMaterial = m_ecranAffichage.material;
        m_ecranAffichage.material = m_videoMaterial;

        for (int i = 0; i < m_videoOrder.Length; i++)
        {
            _videoPlayer.clip = m_videos[m_videoOrder[i]];
            _videoPlayer.Play();
            _audioSource.Play();
            yield return new WaitForSeconds((float)_videoPlayer.length);
        }

        m_ecranAffichage.material = originalMaterial;
    }
}
