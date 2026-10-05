using Unity.Cinemachine;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    // Camera ref
    public CinemachineCamera roomCamera;

    void OnTriggerEnter(Collider other)
    {
        // Is this collider that entered a player script?
        var player = other.GetComponent<CapsuleController>();
        if (player != null)
        {
            // Set a HIGH priority
            roomCamera.Priority = 100;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Is this collider that exited a player script?
        var player = other.GetComponent<CapsuleController>();
        if (player != null)
        {
            // Set a LOW priority
            roomCamera.Priority = -100;
        }
    }
}
