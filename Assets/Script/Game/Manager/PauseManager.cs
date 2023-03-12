using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager: MonoBehaviour
{
    bool isPause = false;
    public void Pause()
    {
        int time = 0;
        time = isPause ? 1 : 0;
        isPause = !isPause;
        Time.timeScale = time;
    }
}
