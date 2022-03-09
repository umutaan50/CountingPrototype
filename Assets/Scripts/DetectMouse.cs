using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouse : MonoBehaviour
{
    public bool isMouseHere = false;

    void OnMouseEnter()
    {
        Debug.Log("Aha fare!");
        isMouseHere = true;
    }

    void OnMouseExit()
    {
        isMouseHere = false;
        Debug.Log("Fare kaçtı!");
    }
}
