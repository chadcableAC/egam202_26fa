using UnityEngine;
using UnityEngine.InputSystem;

public class DemoAnimatorController : MonoBehaviour
{
    InputAction moveAction;
    InputAction aimAction;
    
    public Animator myAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        aimAction = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        var moveAmount = moveAction.ReadValue<Vector2>();
        myAnimator.SetFloat("InputAmount", moveAmount.magnitude);

        if (moveAmount.magnitude > 0.1)
        {
            myAnimator.SetBool("IsWalking", true);
        }
        else
        {
            myAnimator.SetBool("IsWalking", false);
        }

        myAnimator.SetBool("IsAiming", aimAction.IsPressed());
    }
}
