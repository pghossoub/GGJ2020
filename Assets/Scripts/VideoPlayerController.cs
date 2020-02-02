using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoFragmentVariable m_activeFragment;
    public VideoFragmentList m_workbenchFragments;

    public Renderer m_loupe;
    public Renderer m_screen;

    public Material m_videoMaterial;

    private VideoPlayer _videoPlayer;
    private Renderer _activeRenderer;

    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.playOnAwake = false;
    }

    private void Start()
    {
        _videoPlayer.targetTexture.Release();
    }

    public void PlayLoupe()
    {
        _videoPlayer.targetTexture.Release();
        _activeRenderer = m_loupe;
        StartCoroutine(_PlayLoupe());
    }

    private IEnumerator _PlayLoupe()
    {
        Material originalMaterial = _activeRenderer.material;
        _activeRenderer.sharedMaterial = m_videoMaterial;

        _videoPlayer.clip = m_activeFragment.Value.m_clip;
        _videoPlayer.Play();
        yield return new WaitForSeconds((float)_videoPlayer.length);
        _activeRenderer.sharedMaterial = originalMaterial;
        _videoPlayer.targetTexture.Release();
    }

    public void PlayScreen()
    {
        _videoPlayer.targetTexture.Release();
        _activeRenderer = m_screen;
        StartCoroutine(_PlayScreen());
    }


    private IEnumerator _PlayScreen()
    {
        Material originalMaterial = _activeRenderer.material;
        _activeRenderer.sharedMaterial = m_videoMaterial;
        for (int i = 0; i < m_workbenchFragments.m_list.Count; i++)
        {
            _videoPlayer.clip = m_workbenchFragments.m_list[i].m_clip;
            _videoPlayer.Play();
            yield return new WaitForSeconds((float)_videoPlayer.length);
        }
        _activeRenderer.sharedMaterial = originalMaterial;
        _videoPlayer.targetTexture.Release();
    }
}
