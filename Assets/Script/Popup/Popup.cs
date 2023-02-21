using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    bool isOpen = false;
    static GameObject currentPopup;

    public static GameObject CurrentPopup { get => currentPopup; set => currentPopup = value; }

    public void OpenPopup()
    {
        currentPopup = gameObject;
        currentPopup.SetActive(true);
        isOpen = true;
    }
    public void ClosePopup()
    {
        if(currentPopup != null) currentPopup.SetActive(false);
        currentPopup = null;
        isOpen = false;
    }
    public void TogglePopup()
    {
        bool isOpen = this.isOpen;
        ClosePopup();
        if(!isOpen) OpenPopup();
    }
}
