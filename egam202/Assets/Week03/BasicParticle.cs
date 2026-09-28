using UnityEngine;

public class BasicParticle : MonoBehaviour
{
    // Particle ref
    public ParticleSystem fx;

    public void PlayEffect()
    {
        // Play the particle
        fx.Play();
    }
}
