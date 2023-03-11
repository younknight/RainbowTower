using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetManager : MonoBehaviour
{
    JsonManager jsonManager = new JsonManager();
    public void ResetData(bool IsTrue)
    {
        DataManager.instance.ResetData(new DataPlayer(IsTrue), new DataSetting());
        DataManager.instance.Save();
        SceneManager.LoadScene("Main");
    }
}
