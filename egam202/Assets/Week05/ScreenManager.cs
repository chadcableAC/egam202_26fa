using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    // List of our screens
    public enum Screens
    {
        Splash,     // 0
        MainMenu,   // 1
        Settings,   // 2
        Gameplay,   // 3
        Pause       // 4
    }

    // Our current screen
    public Screens currentScreen;

    // List of all screens
    public GameObject splashHandle;
    public GameObject mainMenuHandle;
    public GameObject settingsHandle;
    public GameObject gameplayHandle;
    public GameObject pauseHandle;

    // Vairables for Splash
    float splashTimer;
    public float splashDuration;

    void Start()
    {
        // Default to the splash screen
        SetState(Screens.Splash);
    }

    // Change the current state/screen
    public void SetState(Screens newScreen)
    {
        // Remember the new screen
        currentScreen = newScreen;

        // Turn the game objects on and off
        splashHandle.SetActive(currentScreen == Screens.Splash);
        mainMenuHandle.SetActive(currentScreen == Screens.MainMenu);
        settingsHandle.SetActive(currentScreen == Screens.Settings);
        gameplayHandle.SetActive(currentScreen == Screens.Gameplay);
        pauseHandle.SetActive(currentScreen == Screens.Pause);
    }

    // Functions for switching the current screen
    public void SetMainMenu()
    {
        SetState(Screens.MainMenu);
    }

    public void SetSettings()
    {
        SetState(Screens.Settings);
    }

    public void SetGameplay()
    {
        SetState(Screens.Gameplay);
    }

    public void SetPause()
    {
        SetState(Screens.Pause);
    }

    void Update()
    {
        switch (currentScreen)
        {
            // If currentScreen == Screens.Splash
            case Screens.Splash:
                UpdateSplash();
                break;

            // If currentScreen == Screens.MainMenu
            case Screens.MainMenu:
                UpdateMainMenu();
                break;

            case Screens.Settings:
                UpdateSettings();
                break;

            case Screens.Gameplay:
                UpdateGameplay();
                break;

            case Screens.Pause:
                UpdatePause();
                break;
        }    
    }

    void UpdateSplash()
    {
        // Count up the timer until we pass the duration
        splashTimer += Time.deltaTime;
        if (splashTimer >= splashDuration)
        {
            SetState(Screens.MainMenu);
        }
    }

    void UpdateMainMenu()
    {
        
    }

    void UpdateGameplay()
    {
        
    }

    void UpdateSettings()
    {
        
    }

    void UpdatePause()
    {
        
    }
}
