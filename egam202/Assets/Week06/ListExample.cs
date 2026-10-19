using System.Collections.Generic;
using UnityEngine;

public class ListExample : MonoBehaviour
{
    public List<int> intList;
    public List<string> stringList;

    void Start()
    {
        // Go through the list one by one
        foreach (int element in intList)
        {
            Debug.Log(element);
        }

        foreach (string element in stringList)
        {
            Debug.Log(element);
        }
    }
}
