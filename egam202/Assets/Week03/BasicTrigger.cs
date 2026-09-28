using UnityEngine;

public class BasicTrigger : MonoBehaviour
{
    // Reference to visuals
    public Renderer myRenderer;

    void OnTriggerEnter(Collider other)
    {
        myRenderer.material.color = Color.red;
    }

    void OnTriggerStay(Collider other)
    {
        myRenderer.material.color = Color.yellow;
    }

    void OnTriggerExit(Collider other)
    {
        myRenderer.material.color = Color.blue;
    }
}
