using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelect : MonoBehaviour
{
    [SerializeField] GameObject main;
    [SerializeField] GameObject stage;
    public void Start()
    {
        stage.SetActive(false);
    }
    public void SetStage()
    {
        main.SetActive(false);
        stage.SetActive(true);
    }
    public void SetMain()
    {

        main.SetActive(true);
        stage.SetActive(false);
    }
}
