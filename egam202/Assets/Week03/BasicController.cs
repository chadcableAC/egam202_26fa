using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleController : MonoBehaviour
{
    // Physics object
    public Rigidbody myRigidbody;

    // Input info
    InputAction movementAction;
    public float movementStrength = 1f;

    void Start()
    {
        // Find this action
        movementAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        // Determine player input
        var inputDirection = movementAction.ReadValue<Vector2>();
        
        // Re-map the input to player velocity
        var movementDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
        
        // Limit input to a max length
        if (movementDirection.magnitude > 1)
        {
            movementDirection = movementDirection.normalized;
        }

        // Adjust the overall strength of input
        movementDirection *= movementStrength;

        // Copy the existing Y velocity
        movementDirection.y = myRigidbody.linearVelocity.y;

        // Apply to the rigidbody
        myRigidbody.linearVelocity = movementDirection;
    }
}
