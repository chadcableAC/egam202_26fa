using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class NavAgentController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject indicator;

    void Update()
    {
        // Follow mouse position
        var mouse = Mouse.current;
        if (mouse != null)
        {
            if (mouse.leftButton.wasPressedThisFrame)
            {
                var ray = Camera.main.ScreenPointToRay(mouse.position.value);
                if (Physics.Raycast(ray, out var hitInfo))
                {
                    agent.isStopped = false;
                    agent.destination = hitInfo.point;
                    indicator.SetActive(true);
                    indicator.transform.position = hitInfo.point;
                }
            }
            else if (mouse.rightButton.wasPressedThisFrame)
            {
                agent.isStopped = true;
                indicator.SetActive(false);
            }
        }
    }
}
