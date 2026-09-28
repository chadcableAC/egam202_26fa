using UnityEngine;

public class ShakeEffect : MonoBehaviour
{
    // Handle to move
    public Transform shakeTransform;

    // Shake properties
    public Vector3 shakeStrength = Vector3.one;
    public float shakeDuration = 1f;

    float shakeTimer = -1;


    public void PlayShake()
    {
        shakeTimer = 0;
    }

    void Update()
    {
        if (shakeTimer >= 0)
        {
            // Count up by the amount of time since the last frame
            shakeTimer += Time.deltaTime;

            // When we're longer than the duration, stop the effect
            if (shakeTimer > shakeDuration)
            {
                shakeTimer = -1;
                shakeTransform.localPosition = Vector3.zero;
            }
            else
            {
                Vector3 shakeOffset = Vector3.zero;

                shakeOffset.x = Random.Range(-shakeStrength.x, shakeStrength.x);
                shakeOffset.y = Random.Range(-shakeStrength.y, shakeStrength.y);
                shakeOffset.z = Random.Range(-shakeStrength.z, shakeStrength.z);

                shakeTransform.localPosition = shakeOffset;
            }
        }
    }
}
