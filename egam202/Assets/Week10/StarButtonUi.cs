using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarButtonUi : MonoBehaviour
{
    public int numberOfStars;

    public TextMeshProUGUI text;

    void Start()
    {
        // Change text based on the number of stars
        switch (numberOfStars)
        {
            case 1:
                text.text = "One Star";
                break;
            case 2:
                text.text = "Two Stars";
                break;
            case 3:
                text.text = "Three Stars";
                break;
        }
    }

    public void OnPressed()
    {
        var saveKey = SceneManager.GetActiveScene().name;

        // Set that this level has been played
        var playedSaveKey = saveKey + "_played";
        PlayerPrefs.SetInt(playedSaveKey, 1);

        // Set the number of stars
        PlayerPrefs.SetInt(saveKey, numberOfStars);

        Debug.Log("Saving " + numberOfStars + " stars for level " + saveKey);
    }
}
