using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectButtonUi : MonoBehaviour
{
    // Visual info
    public Button button;
    public TextMeshProUGUI text;

    // Scene info
    String sceneName;

    void Start()
    {
        // Subscribe for click events
        button.onClick.AddListener(OnButtonClicked);    
    }

    public void SetLevel(String levelSceneName)
    {
        // Remember the scene
        sceneName = levelSceneName;

        RefreshStarCount();
    }

    public void SetLocked(bool isLocked)
    {
        button.interactable = !isLocked;
    }

    public void OnButtonClicked()
    {
        // Load the new scene
        SceneManager.LoadScene(sceneName);
    }

    void OnEnable()
    {
        RefreshStarCount();
    }

    void RefreshStarCount()
    {
        // See if we have any data saved
        var starCount = 0;
        if (PlayerPrefs.HasKey(sceneName))
        {
            starCount = PlayerPrefs.GetInt(sceneName);
        }

        // Update the text to match
        var buttonText = sceneName;
        switch (starCount)
        {
            case 1:
                buttonText += " *";
                break;
            case 2:
                buttonText += " **";
                break;
            case 3:
                buttonText += " ***";
                break;
        }

        // Change the text we're displaying
        text.text = buttonText;        
    }

    public bool HasLevelBeenPlayed()
    {
        // Generate the unique key
        var playedSaveKey = sceneName + "_played";
        var hasPlayed = false;

        // See if the value exists
        if (PlayerPrefs.HasKey(playedSaveKey))
        {
            // Get the value
            var keyValue = PlayerPrefs.GetInt(playedSaveKey);
            
            // We can only save ints, so 1 = true and 0 = false
            if (keyValue == 1)
            {
                hasPlayed = true;
            }
        }

        Debug.Log("Level " + sceneName + ", has played: " + hasPlayed);

        return hasPlayed;
    }
}