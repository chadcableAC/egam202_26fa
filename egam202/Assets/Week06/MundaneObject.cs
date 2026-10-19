using UnityEngine;

public class MundaneObject : MonoBehaviour
{
    // Define the total number of colors
    public enum ColorTypes
    {
        Red,
        Blue,
        Yellow,
        Green
    }

    public ColorTypes myColor;

    // Visual settings
    public MeshRenderer myRenderer;

    void Start()
    {
        switch (myColor)
        {
            case ColorTypes.Red:
                myRenderer.material.color = Color.red;
                break;
            case ColorTypes.Blue:
                myRenderer.material.color = Color.blue;
                break;
            case ColorTypes.Yellow:
                myRenderer.material.color = Color.yellow;
                break;
            case ColorTypes.Green:
                myRenderer.material.color = Color.green;
                break;
        }
    }
}
