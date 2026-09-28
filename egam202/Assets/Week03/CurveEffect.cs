using UnityEngine;

public class CurveEffect : MonoBehaviour
{
    // Visual ref
    public Transform moveTransform;

    // Animation values
    public AnimationCurve curve;
    public Vector3 moveDirection = Vector3.up;
    public float moveDuration = 1f;

    float moveTimer;

    void Update()
    {
        // Count up the timer
        moveTimer += Time.deltaTime;

        // If the timer is too big, reset it to zero (loop the effect)
        if (moveTimer > moveDuration)
        {
            moveTimer = 0;
        }

        // Find the "interp" (value between 0 and 1)
        var moveInterp = moveTimer / moveDuration;

        // Ask the curve for a new position
        moveInterp = curve.Evaluate(moveInterp);

        // Apply to the handle
        moveTransform.localPosition = moveDirection * moveInterp;
    }
}
