using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManger : MonoBehaviour
{
    public void MoveSelectStage()
    {
        SceneManager.LoadScene("SelectStage");
        DataManager.instance.Save();
    }
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoHome()
    {
        SceneManager.LoadScene("Main");
        DataManager.instance.Save();
    }
    public void GoTest()
    {
        SceneManager.LoadScene("TestGame");
    }
}
