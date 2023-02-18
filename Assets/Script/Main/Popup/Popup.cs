using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    bool isOpen = false;
    static GameObject currentPopup;

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
    public void ClosePopup()
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
