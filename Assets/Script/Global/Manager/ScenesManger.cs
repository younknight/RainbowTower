using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManger : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
        DataManager.instance.Save();
    }
    public void GoMainWithSave()
    {
        SceneManager.LoadScene("Main");
        DataManager.instance.Save();
    }
    public void GoMain()
    {
        if(DataManager.DataPlayer.clearedStory[1]) SceneManager.LoadScene("Main");
        else SceneManager.LoadScene("Story");
    }
}
