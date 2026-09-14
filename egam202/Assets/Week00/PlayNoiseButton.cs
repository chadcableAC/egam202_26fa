using UnityEngine;

public class PlayNoiseButton : MonoBehaviour
{
    public AudioSource source;

    public void PlaySound()
    {
        // Play the SFX on this source
        source.Play();
    }
}
