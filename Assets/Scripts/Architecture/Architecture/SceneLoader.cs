using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

using Marsheleene.Architecture;

public class SceneLoader : GlobalSingletonGameObject<SceneLoader>
{
    public List<string> m_scenesToLoad;

    protected override void InitAwake()
    {
        foreach (string scene in m_scenesToLoad)
        {
            if (!string.IsNullOrEmpty(scene))
            {
                LoadSceneAdditive(scene);
            }
        }
    }

    public AsyncOperation LoadScene(string sceneName)
    {
        return SceneManager.LoadSceneAsync(sceneName);
    }

    public AsyncOperation LoadSceneAdditive(string sceneName)
    {
        return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    public AsyncOperation UnLoadScene(string sceneName)
    {
        return SceneManager.UnloadSceneAsync(sceneName);
    }
}
