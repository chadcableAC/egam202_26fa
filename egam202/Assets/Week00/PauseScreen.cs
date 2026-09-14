using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    void Start()
    {
        // Start with the screen turned off
        HideScreen();
    }

    public void ShowScreen()
    {
        // Turn on this screen
        gameObject.SetActive(true);
    }
    
    public void HideScreen()
    {
        // Turn off this screen
        gameObject.SetActive(false);
    }
}
