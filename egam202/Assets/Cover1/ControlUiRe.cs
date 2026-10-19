using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlUiRe : MonoBehaviour
{
    // Button
    public Button button;
    public TextMeshProUGUI buttonLabel;

    PlayerControllerRe controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button.onClick.AddListener(OnPressed);

        controller = FindAnyObjectByType<PlayerControllerRe>();
        RefreshButton();
    }

    void OnPressed()
    {
        controller.NextControls();
        RefreshButton();        
    }

    void RefreshButton()
    {
        var type = controller.currentControls;
        switch (type)
        {
            case PlayerControllerRe.ControlTypes.Tank:
                buttonLabel.text = "Tank Controls";
                break;
            case PlayerControllerRe.ControlTypes.Modern:
                buttonLabel.text = "Modern Controls";
                break;
            case PlayerControllerRe.ControlTypes.Mouse:
                buttonLabel.text = "Mouse Controls";
                break;
        }
    }
}
