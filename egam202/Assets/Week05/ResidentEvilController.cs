using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ResidentEvilController : MonoBehaviour
{
    // Control schemes
    public enum ControlTypes
    {
        Tank,
        Modern,
        Mouse
    }

    public ControlTypes currentControls;

    // Input info
    InputAction movementAction;

    public Vector2 movementStrengthTank = Vector2.one;
    public Vector2 movementStrengthModern = Vector2.one;

    // Character info
    public NavMeshAgent agent;
    public Rigidbody myRigidbody;

    void Start()
    {
        // Find this action
        movementAction = InputSystem.actions.FindAction("Move");

        // Set the initial state
        SetControls(ControlTypes.Mouse);
    }

    public void SetControls(ControlTypes newControls)
    {
        // Set the current
        currentControls = newControls;

        // Turn the rigidbody and agent on/off based on the state
        switch (currentControls)
        {
            case ControlTypes.Tank:
            case ControlTypes.Modern:
                // Turn off the agent
                agent.enabled = false;
                // Turn on the rigidbody
                myRigidbody.isKinematic = false;
                break;
            case ControlTypes.Mouse:
                // Turn on the agent
                agent.enabled = true;
                // Turn off the rigidbody
                myRigidbody.isKinematic = true;
                break;
        }
    }

    void Update()
    {
        switch (currentControls)
        {
            case ControlTypes.Tank:
                UpdateTank();
                break;
            case ControlTypes.Modern:
                UpdateModern();
                break;
            case ControlTypes.Mouse:
                UpdateMouse();
                break;
        }    
    }

    void UpdateTank()
    {
        // Find the input
        var moveInput = movementAction.ReadValue<Vector2>();
        
        // Make sure the length is never more than 1
        if (moveInput.magnitude > 1)
        {
            moveInput = moveInput.normalized;
        }

        // Up/down input = forward and backward movement
        var velocity = Vector3.zero;
        var myForward = transform.forward;

        if (moveInput.y != 0)
        {
            // Move along the forward times the up/down input
            velocity = myForward * moveInput.y * movementStrengthTank.y;
        }

        // Maintain the current y velocity
        velocity.y = myRigidbody.linearVelocity.y;

        // Set the velocity on the rigidboy
        myRigidbody.linearVelocity = velocity;

        // Left/right input = turn left/right
        var angularVelocity = Vector3.zero;

        if (moveInput.x != 0)
        {
            var rotateAmount = moveInput.x * movementStrengthTank.x;
            angularVelocity.y = rotateAmount;
        }

        myRigidbody.angularVelocity = angularVelocity;
    }

    void UpdateModern()
    {
        // Find the input value
        var moveInput = movementAction.ReadValue<Vector2>();
        
        // Make sure the length is never more than 1
        if (moveInput.magnitude > 1)
        {
            moveInput = moveInput.normalized;
        }

        // Find the camera direction
        var mainCamera = Camera.main;
        var cameraForward = mainCamera.transform.forward;
        var cameraRight = mainCamera.transform.right;

        // Map the input values onto the camera directions
        var velocity = Vector3.zero;
        velocity += cameraRight * moveInput.x * movementStrengthModern.x;
        velocity += cameraForward * moveInput.y * movementStrengthModern.y;

        // "Maintain" the y velocity
        velocity.y = myRigidbody.linearVelocity.y;

        // Apply the velocity to the rigidbody
        myRigidbody.linearVelocity = velocity;

        // We want to face the direction movement
        var lookAtOffset = velocity;
        lookAtOffset.y = 0;

        if (lookAtOffset.magnitude > 0.1)
        {
            // Look at a position offset from ours
            transform.LookAt(transform.position + lookAtOffset);
        }

        // Ensure there's NO angular rotation
        myRigidbody.angularVelocity = Vector3.zero;
    }

    void UpdateMouse()
    {
        // Find the mouse position
        var mouse = Mouse.current;
        if (mouse != null)
        {
            var mousePosition = mouse.position.value;
            
            // Convert from screen space to world space (From UI to 3D)
            var camera = Camera.main;
            var worldRay = camera.ScreenPointToRay(mousePosition);

            // More debug info
            var isHit = false;

            // Project a "ray" from the camera into space
            if (Physics.Raycast(worldRay.origin, worldRay.direction, out RaycastHit hitInfo))
            {
                // Only set the destination on mouse clicks
                if (mouse.leftButton.wasPressedThisFrame)
                {
                    // If we hit something, set that as the movement target
                    agent.destination = hitInfo.point;
                }

                // Hit somethning!
                isHit = true;
                Debug.DrawRay(hitInfo.point, Vector3.up, Color.white);
            }

            if (isHit)
            {
                Debug.DrawRay(worldRay.origin, worldRay.direction * 100, Color.green);
            }
            else
            {
                Debug.DrawRay(worldRay.origin, worldRay.direction * 100, Color.red);
            }
        }
    }
}
