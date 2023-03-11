using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject stage;
    static bool isMain = true;

    public static bool IsMain { get => isMain; }

    public void Start()
    {
        stage.SetActive(false);
    }
    public void ToggleMode()
    {
        isMain = !isMain;
        main.SetActive(isMain);
        stage.SetActive(!isMain);
    }
}
