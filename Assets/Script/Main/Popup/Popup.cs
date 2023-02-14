using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    static bool isOpen = false;
    static GameObject currentPopup;

    public static bool IsOpen { get => isOpen; }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void OpenPopup()
    {
        currentPopup = gameObject;
        currentPopup.SetActive(true);
        isOpen = true;
    }
    public static void ClosePopup()
    {
        currentPopup.SetActive(false);
        isOpen = false;
    }
    public void TogglePopup()
    {
        if (isOpen) ClosePopup();
        else OpenPopup();
    }
}
