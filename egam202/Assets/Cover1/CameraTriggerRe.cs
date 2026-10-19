using Unity.Cinemachine;
using UnityEngine;

public class CameraTriggerRe : MonoBehaviour
{
    public CinemachineCamera cam;
    public bool isDefault = false;

    void Start()
    {
        if (isDefault)
        {
            cam.Prioritize();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerControllerRe>();
        if (player)
        {
            cam.Prioritize();
        }
    }
}
