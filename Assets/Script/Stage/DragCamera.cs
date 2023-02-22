using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCamera : MonoBehaviour
{
    public static bool isClicked = false;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isClicked = false;
        }
    }
}
