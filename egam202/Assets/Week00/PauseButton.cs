using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public void ShowPauseScreen()
    {
        // Find the object with the script PauseScreen on it
        // Include objects that might be turned off / set inactive
        var pauseScreen = FindAnyObjectByType<PauseScreen>(FindObjectsInactive.Include);
        // Show that screen
        pauseScreen.ShowScreen();
    }
}
