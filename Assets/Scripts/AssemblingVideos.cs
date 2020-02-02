using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AssemblingVideos : MonoBehaviour
{
    public VideoFragmentListVariable m_activeFragments;

    public Renderer m_loupe;
    public Renderer m_screen;

    public Material m_videoMaterial;

    private VideoPlayer _videoPlayer;
    private Renderer _activeRenderer;
    //private AudioSource _audioSource;

    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.playOnAwake = false;
        //_audioSource = gameObject.GetComponent<AudioSource>();
        //_audioSource.playOnAwake = false;
    }

    private void Start()
    {
        _videoPlayer.targetTexture.Release();
        //StartCoroutine("ReadVideos");
        m_activeFragments.m_fragments = FindObjectsOfType<VideoFragment>();
    }

    //IEnumerator ReadVideos()
    //{
    //    Material originalMaterial = m_ecranAffichage.material;
    //    m_ecranAffichage.material = m_videoMaterial;

    //    for (int i = 0; i < m_videoOrder.Length; i++)
    //    {
    //        //_videoPlayer.clip = m_videos[m_videoOrder[i]];
    //        _videoPlayer.Play();
    //        //_audioSource.Play();
    //        yield return new WaitForSeconds((float)_videoPlayer.length);
    //    }

    //    m_ecranAffichage.material = originalMaterial;
    //}

    public void PlayLoupe()
    {
        _activeRenderer = m_loupe;
        PlayFragments();
    }

    public void PlayScreen()
    {
        _activeRenderer = m_screen;
        PlayFragments();
    }

    private void PlayFragments()
    {
        StartCoroutine(_PlayFragments());
    }

    private IEnumerator _PlayFragments()
    {
        _videoPlayer.targetTexture.Release();
        Material originalMaterial = _activeRenderer.material;
        _activeRenderer.sharedMaterial = m_videoMaterial;
        for (int i = 0; i < m_activeFragments.m_fragments.Length; i++)
        {
            _videoPlayer.clip = m_activeFragments.m_fragments[i].m_clip;
            _videoPlayer.Play();
            yield return new WaitForSeconds((float)_videoPlayer.length);
        }
        _activeRenderer.sharedMaterial = originalMaterial;
        //_videoPlayer.targetTexture.Release();
    }
}
