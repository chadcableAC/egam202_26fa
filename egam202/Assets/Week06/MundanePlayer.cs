using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MundanePlayer : MonoBehaviour
{
    // Input info
    InputAction interactAction;
    InputAction movementAction;

    public Vector2 movementStrength = Vector2.one;

    // Character info
    public Rigidbody myRigidbody;

    // Object info
    public List<MundaneObject> interactableObjects;

    // Carry info
    public Transform dropHandle;
    public float dropRadius = 1f;

    public Transform carryHandle;
    public float carryDistance = 1f;
    public List<MundaneObject> carryObjects;


    void Start()
    {
        // Find this action
        interactAction = InputSystem.actions.FindAction("Jump");
        movementAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        // Look for button presses
        if (interactAction.WasPressedThisFrame())
        {
            TryInteract();
        }

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
        velocity += cameraRight * moveInput.x * movementStrength.x;
        velocity += cameraForward * moveInput.y * movementStrength.y;

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

    void TryInteract()
    {
        // Only pick up if something is in our list
        if (interactableObjects.Count > 0)
        {
            // If there are any objects in our list, pick them up!
            foreach (var interactableObject in interactableObjects)
            {
                Pickup(interactableObject);
            }
            interactableObjects.Clear();
        }
        // Otherwise place down
        else
        {
            // Also try to place things down
            TryPlace();
        }
    }

    void Pickup(MundaneObject mundaneObject)
    {
        // Add it to our list
        carryObjects.Add(mundaneObject);

        // Place underneath the carry transform
        mundaneObject.transform.SetParent(carryHandle);

        // Offset it by the place in the list
        var listIndex = carryObjects.Count - 1;
        var offset = Vector3.up * listIndex * carryDistance;
        mundaneObject.transform.localPosition = offset;
    }

    void TryPlace()
    {
        // Are we carrying anything?
        if (carryObjects.Count > 0)
        {
            // See if there are any interact zones nearby
            var colliders = Physics.OverlapSphere(dropHandle.position, dropRadius);

            // Then, is this zone empty?
            foreach (var collider in colliders)
            {
                var zone = collider.GetComponent<MundaneZone>();
                if (zone)
                {
                    // We can actually place the object here!
                    var index = carryObjects.Count - 1;
                    var mundaneObject = carryObjects[index];

                    // Call the "placing" logic
                    zone.PlacingObject(mundaneObject);

                    // Don't want to track this anymore
                    carryObjects.Remove(mundaneObject);

                    // Don't try to place anymore
                    return;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        var mundaneObject = other.transform.GetComponent<MundaneObject>();
        if (mundaneObject)
        {
            interactableObjects.Add(mundaneObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        var mundaneObject = other.transform.GetComponent<MundaneObject>();
        if (mundaneObject)
        {
            interactableObjects.Remove(mundaneObject);
        }
    }
}
