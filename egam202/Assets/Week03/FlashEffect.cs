using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    // Renderer info
    public Renderer myRenderer;

    // Flash info
    public float flashDuration = 1f;
    public Color flashColor = Color.white;

    float flashTimer;
    Color originalColor;
    Color tempColor;

    void Start()
    {
        // Remember the original object color
        originalColor = myRenderer.material.color;
    }

    public void Flash()
    {
        // Start the flash effect, so reset the timer
        flashTimer = 0;
        tempColor = flashColor;
    }

    public void FlashRed()
    {
        // Start the flash effect, so reset the timer
        flashTimer = 0;
        tempColor = Color.red;
    }

    void Update()
    {
        if (flashTimer >= 0)
        {
            // Increment the timer by how much time has passed since the last frame
            flashTimer += Time.deltaTime;
            
            // After the duration, reset the effect
            if (flashTimer > flashDuration)
            {
                flashTimer = -1;
                myRenderer.material.color = originalColor; 
            }
            else
            {
                // Turn the timer into an "interp" (between 0 and 1)
                var interp = flashTimer / flashDuration;

                // Go from flash (0) to original color (1)
                var color = Color.Lerp(tempColor, originalColor, interp);

                myRenderer.material.color = color; 
            }
        }
    }
}
