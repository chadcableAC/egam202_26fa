using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastManager : MonoBehaviour
{
    void Update()
    {
        // Find all meshes and make them gray
        var allMeshes = FindObjectsByType<MeshRenderer>();
        foreach (var mesh in allMeshes)
        {
            mesh.material.color = Color.grey;
        }

        // Then see if any mesh is under the mouse and turn it red
        var mouse = Mouse.current;
        if (mouse != null)
        {
            var mainCam = Camera.main;
            var mousePos = mouse.position.value;
            var mouseRay = mainCam.ScreenPointToRay(mousePos);

            Debug.DrawRay(mouseRay.origin, mouseRay.direction * 100);
            
            // "Single" raycast that returns the first object it hits
            // if (Physics.Raycast(mouseRay, out RaycastHit hitInfo))
            // {
            //     // Inside of here is the logic for hitting an object
            //     var mesh = hitInfo.transform.GetComponent<MeshRenderer>();
            //     if (mesh)
            //     {
            //         mesh.material.color = Color.red;
            //     }
            // }

            // "All" will return every object the ray hits (The ray doesn't stop after colliding with an object)
            var hitInfoList = Physics.RaycastAll(mouseRay);
            foreach (var eachHitInfo in hitInfoList)
            {
                // Inside of here is the logic for hitting an object
                var mesh = eachHitInfo.transform.GetComponent<MeshRenderer>();
                if (mesh)
                {
                    mesh.material.color = Color.red;
                }
            }
        }
    }
}
