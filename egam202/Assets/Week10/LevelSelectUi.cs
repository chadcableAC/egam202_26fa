using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUi : MonoBehaviour
{
    public LevelSelectButtonUi levelSelectButton;
    public Transform levelButtonParent;
    public List<String> sceneNames;
    List<LevelSelectButtonUi> levelButtons = new();

    public GameObject levelSelectHandle;
    bool isLevelSelectOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Create all of the buttons
        foreach (String sceneName in sceneNames)
        {
            // Make the button
            var newButton = Instantiate<LevelSelectButtonUi>(levelSelectButton);

            // Make it a child of the grid layout group
            newButton.transform.SetParent(levelButtonParent, false);

            // Tell teh button which scene / level this is pointing to
            newButton.SetLevel(sceneName);

            // Add this button to our list
            levelButtons.Add(newButton);
        }

        RefreshLockState();

        // Start the scene with this UI turned off
        isLevelSelectOn = false;
        levelSelectHandle.SetActive(isLevelSelectOn);
    }

    public void OnPausePressed()
    {
        // Toggle the level select UI on and off
        isLevelSelectOn = !isLevelSelectOn;
        levelSelectHandle.SetActive(isLevelSelectOn);

        RefreshLockState();
    }

    public void OnResetPressed()
    {
        // Deletes all keys
        PlayerPrefs.DeleteAll();
        
        RefreshLockState();
    }

    void RefreshLockState()
    {
        // Players need to play levels in order
        // Unlock levels one by one
        var isLocked = false;
        foreach (var button in levelButtons)
        {
            // Set the level to locked or not
            button.SetLocked(isLocked);

            // See if this level has been played
            var hasPlayed = button.HasLevelBeenPlayed();
            if (hasPlayed == false)
            {
                isLocked = true;
            }
        }
    }
}
