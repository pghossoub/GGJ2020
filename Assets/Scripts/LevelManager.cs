using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public string m_currentLevel;
    public string m_nextLevel;

    [ContextMenu("NextLevel")]
    public void LoadNextLevel()
    {
        SceneLoader.Instance.LoadSceneAdditive(m_nextLevel);
        SceneLoader.Instance.UnLoadScene(m_currentLevel);
    }
}
