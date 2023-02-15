using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManger : MonoBehaviour
{
    public void MoveSelectStage()
    {
        SceneManager.LoadScene("SelectStage");
    }
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoHome()
    {
        SceneManager.LoadScene("Main");
    }
    public void GoTest()
    {
        SceneManager.LoadScene("TestGame");
    }
}
