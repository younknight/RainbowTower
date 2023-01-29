using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public static bool isOpen = false;
    static GameObject currentPopup;
    private void Start()
    {
        gameObject.SetActive(isOpen);
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
}
