using UnityEngine;
using UnityEngine.InputSystem;

public class MixamoTest : MonoBehaviour
{
    public Animator animator;

    InputAction moveAction;
    InputAction aimAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        aimAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        var move = moveAction.ReadValue<Vector2>();
        var isMoving = move.magnitude > 0.1;
        animator.SetBool("walking", isMoving);

        var isAiming = aimAction.IsPressed();
        animator.SetBool("aiming", isAiming);
    }
}
