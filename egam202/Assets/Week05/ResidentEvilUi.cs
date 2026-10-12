using UnityEngine;
using UnityEngine.UI;

public class ResidentEvilUi : MonoBehaviour
{
    public Button buttonTank;
    public Button buttonModern;
    public Button buttonMouse;

    void Start()
    {
        // Listen for button presses
        buttonTank.onClick.AddListener(SetTank);
        buttonModern.onClick.AddListener(SetModern);
        buttonMouse.onClick.AddListener(SetMouse);
    }

    public void SetTank()
    {
        // Find the controller script
        var controller = FindAnyObjectByType<ResidentEvilController>();
        
        // If it's valid, change the control type
        if (controller)
        {
            controller.SetControls(ResidentEvilController.ControlTypes.Tank);
        }
    }

    public void SetModern()
    {
        // Find the controller script
        var controller = FindAnyObjectByType<ResidentEvilController>();
        
        // If it's valid, change the control type
        if (controller)
        {
            controller.SetControls(ResidentEvilController.ControlTypes.Modern);
        }
    }

    public void SetMouse()
    {
        // Find the controller script
        var controller = FindAnyObjectByType<ResidentEvilController>();
        
        // If it's valid, change the control type
        if (controller)
        {
            controller.SetControls(ResidentEvilController.ControlTypes.Mouse);
        }
    }
}
