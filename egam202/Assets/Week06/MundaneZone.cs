using UnityEngine;

public class MundaneZone : MonoBehaviour
{
    public Transform placeHandle;

    // Visual settings
    public MundaneObject.ColorTypes myColor;
    public MeshRenderer myRenderer;

    public FlashEffect flash;
    public ShakeEffect shake;

    void Awake()
    {
        switch (myColor)
        {
            case MundaneObject.ColorTypes.Red:
                myRenderer.material.color = Color.red;
                break;
            case MundaneObject.ColorTypes.Blue:
                myRenderer.material.color = Color.blue;
                break;
            case MundaneObject.ColorTypes.Yellow:
                myRenderer.material.color = Color.yellow;
                break;
            case MundaneObject.ColorTypes.Green:
                myRenderer.material.color = Color.green;
                break;
        }
    }

    void Start()
    {
        // Find an object without a parent
        var allMundaneObjects = FindObjectsByType<MundaneObject>();
        foreach (var mundaneObject in allMundaneObjects)
        {
            // Check if they're already inside a zone
            var zoneParent = mundaneObject.GetComponentInParent<MundaneZone>();
            if (zoneParent != null)
            {
                // Alrady placed
            }
            else if (myColor == mundaneObject.myColor)
            {
                // Matching colors - don't place here!
            }
            else
            {
                // Place the object ourselves
                PlacingObject(mundaneObject);
                return;
            }
        }
    }

    public void PlacingObject(MundaneObject mundaneObject)
    {
        // Switch parents
        mundaneObject.transform.SetParent(placeHandle);
        mundaneObject.transform.localPosition = Vector3.zero;

        // If they're the same, play good feedback!
        if (myColor == mundaneObject.myColor)
        {
            flash.Flash();
        }
        // Otherwise play negative feedback
        else
        {
            shake.PlayShake();
        }
    }
}
