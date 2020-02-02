using System.Collections.Generic;

using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public string m_currentLevel;
    public string m_nextLevel;

    public VideoFragmentList m_workbenchFragments;

    private void Awake()
    {
        m_workbenchFragments.m_list = new List<VideoFragment>(6);
    }


    [ContextMenu("NextLevel")]
    public void LoadNextLevel()
    {
        SceneLoader.Instance.LoadSceneAdditive(m_nextLevel);
        SceneLoader.Instance.UnLoadScene(m_currentLevel);
    }
}
