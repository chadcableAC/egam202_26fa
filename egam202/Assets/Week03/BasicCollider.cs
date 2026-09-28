using UnityEngine;

public class BasicCollider : MonoBehaviour
{
    // Visual reference
    public Renderer myRenderer;

    void OnCollisionEnter(Collision collision)
    {
        myRenderer.material.color = Color.red;
    }

    void OnCollisionStay(Collision collision)
    {
        myRenderer.material.color = Color.yellow;
    }

    void OnCollisionExit(Collision collision)
    {
        myRenderer.material.color = Color.blue;
    }
}
