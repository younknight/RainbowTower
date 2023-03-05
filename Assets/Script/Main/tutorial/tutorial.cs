using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class tutorial : MonoBehaviour
{
    Data data;
    void Start()
    {
        data = DataManager.Data;
        if (!data.tutorialCleared)
        {
            SceneManager.LoadScene("Story");
        }
    }

}
