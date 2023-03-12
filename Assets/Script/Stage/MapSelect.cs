using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject stage;
    static bool isMain;

    public static bool IsMain { get => isMain; }

    void Start()
    {
        isMain = true;
        stage.SetActive(false);
    }
    public void ToggleMode()
    {
        isMain = !isMain;
        main.SetActive(isMain);
        stage.SetActive(!isMain);
    }
}
