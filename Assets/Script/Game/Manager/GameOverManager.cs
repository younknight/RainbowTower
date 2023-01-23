using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    [SerializeField]
    Image gameoverImage;
    [SerializeField]
    TextMeshProUGUI DefeatText;
    [SerializeField]
    TextMeshProUGUI VictoryText;
    bool isPlaying = false;
    float FadeTime = 2f;
    float start = 0f;
    float end = 1f;
    float time;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public void GameOverWithVictory(bool isVictory)
    {
        Debug.Log("게임오버데스");
        if (isPlaying == true) return;
        StartCoroutine(FadeOutPlay());
        if (isVictory)
        {
            StartCoroutine(FadeOutText(VictoryText));
        }
        else
        {
            StartCoroutine(FadeOutText(DefeatText));
        }
        isPlaying = false;
    }
    IEnumerator FadeOutPlay()
    {
        isPlaying = true;
        Color color = gameoverImage.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);
        while (color.a < 1f)
        {
            time += Time.deltaTime / FadeTime;
            color.a = Mathf.Lerp(start, end, time);
            gameoverImage.color = color;
            yield return null;
        }
    }
    IEnumerator FadeOutText(TextMeshProUGUI text)
    {
        Color color = text.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);
        while (color.a < 1f)
        {
            time += Time.deltaTime / FadeTime;
            color.a = Mathf.Lerp(start, end, time);
            text.color = color;
            yield return null;
        }
    }
}
