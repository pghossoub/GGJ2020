using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderMultipleScenes : MonoBehaviour
{

    void Awake()
    {
            SceneManager.LoadScene("Cameras", LoadSceneMode.Additive);
            SceneManager.LoadScene("Environnement", LoadSceneMode.Additive);
            SceneManager.LoadScene("InputControllers", LoadSceneMode.Additive);
    }
}
