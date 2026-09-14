using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ReloadSceneButton : MonoBehaviour
{
    // Variable for tracking an action
    InputAction reloadAction;

    void Start()
    {
        // Store the value using the action’s name
        reloadAction = InputSystem.actions.FindAction("ReloadScene");
    }

    void Update()
    {
        // If players press this action, reload the scene!
        if (reloadAction.WasPressedThisFrame())
        {
            ReloadScene();
        }
    }

    public void ReloadScene()
    {
        // Get the current scene
        var currentScene = SceneManager.GetActiveScene();
        // Load the scene again
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
