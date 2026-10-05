using UnityEngine;
using UnityEngine.InputSystem;

public class CapsuleController : MonoBehaviour
{
    // Physics info
    public Rigidbody myRigidbody;

    // Control info
    public Vector2 moveSpeed = Vector2.one;
    InputAction movementAction;

    void Start()
    {
        // Find this action
        movementAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        // Read the input
        var moveInput = movementAction.ReadValue<Vector2>();

        // Make sure input is never longer than 1
        if (moveInput.magnitude > 1)
        {
            moveInput = moveInput.normalized;
        }

        // Figure out the CAMERA's forward and right
        // NOTE: This works best with 3D camera
        // Camera's straight above us will not move "forward"
        var camera = Camera.main;
        var worldMovement = Vector3.zero;

        // Add in the camera's RIGHT value multiplied by left/right input
        worldMovement += camera.transform.right * moveInput.x;

        // Add in the camera's FORWARD value multiplied by up/down input
        worldMovement += camera.transform.forward * moveInput.y;

        // Adjust the strength
        worldMovement.x *= moveSpeed.x;
        worldMovement.z *= moveSpeed.y;

        // Maintain the y velocity
        worldMovement.y = myRigidbody.linearVelocity.y;

        // Finally assign the value
        myRigidbody.linearVelocity = worldMovement;

        Debug.DrawRay(transform.position, worldMovement);
    }
}
