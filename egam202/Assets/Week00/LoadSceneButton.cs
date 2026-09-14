using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public String sceneName;
    
    public void LoadScene()
    {
        // Load the scene by name
        SceneManager.LoadScene(sceneName);
    }
}
