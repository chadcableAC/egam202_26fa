using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleCameraSwitcher : MonoBehaviour
{
    // List of cameras to switch between
    public List<CinemachineCamera> cameras;

    // List index (which camera we're currently using)
    public int cameraIndex;

    void Start()
    {
        // On start, make this camera the prioroity
        cameras[cameraIndex].Prioritize();
    }

    void Update()
    {
        // Find the mouse
        var mouse = Mouse.current;
        if (mouse != null)
        {
            // On click, switch to the next camera
            if (mouse.leftButton.wasPressedThisFrame)
            {
                // Move to the next index
                cameraIndex++;

                // If the index is bigegr than the lsit, reset it to 0
                if (cameraIndex >= cameras.Count)
                {
                    cameraIndex = 0;
                }

                // Make the current index the priority camera
                cameras[cameraIndex].Prioritize();
            }
        }
    }
}
