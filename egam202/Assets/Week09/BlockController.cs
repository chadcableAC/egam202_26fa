using UnityEngine;
using UnityEngine.InputSystem;

public class BlockController : MonoBehaviour
{
    public Animator myAnimator;
    InputAction jumpAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.WasPressedThisFrame())
        {
            myAnimator.SetTrigger("IsJump");
        }
    }
}
