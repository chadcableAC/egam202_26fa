using UnityEngine;

public class BridgeToggle : MonoBehaviour
{
    public GameObject bridgeObject;
    public GameObject obstacleObject;

    void Start()
    {
        SetBridgeOn(true);
    }

    public void OnPressed()
    {
        SetBridgeOn(!bridgeObject.activeSelf);
    }

    void SetBridgeOn(bool isOn)
    {
        bridgeObject.SetActive(isOn);
        obstacleObject.SetActive(!isOn);
    }
}
