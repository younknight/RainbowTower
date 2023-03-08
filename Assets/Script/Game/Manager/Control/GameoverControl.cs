using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameoverControl : MonoBehaviour
{
    public static GameoverControl instance;
    [SerializeField] Image gameoverImage;
    [SerializeField] TextMeshProUGUI DefeatText;
    [SerializeField] TextMeshProUGUI VictoryText;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] Image button;
    bool isPlaying = false;
    float FadeTime = 2f;
    float start = 0f;
    float end = 1f;
    float time;
    //층수
    bool isFirstClear = false;
    int floorHeight;
    DungeonType dungeonType;
    TalkManager talkManager = new TalkManager();
    public int Floor { get => floorHeight; set => floorHeight = value; }
    public DungeonType DungeonType { get => dungeonType; set => dungeonType = value; }

    private void Awake()
    {
        if (instance == null) instance = this;
        gameObject.SetActive(false);
    }
    public void GameOverWithVictory(bool isVictory)
    {
        if (isPlaying == true) return;
        gameObject.SetActive(true);
        Debug.Log("게임오버데스");
        StartCoroutine(FadeOutPlay());
        StartCoroutine(FadeOutText(buttonText));
        if (isVictory)//승리
        {
            StartCoroutine(FadeOutText(VictoryText));
            if (DataManager.Data.clearFloor[EnemyManager.instance.FloorPrefap.dungeonType] <= EnemyManager.instance.FloorPrefap.height)
            {
                isFirstClear = true;
                DataManager.Data.clearFloor[EnemyManager.instance.FloorPrefap.dungeonType] = EnemyManager.instance.FloorPrefap.height;
            }
        }
        else//패배
        {
            StartCoroutine(FadeOutText(DefeatText));
        }
        DataManager.instance.Save();
    }
    IEnumerator FadeOutPlay()
    {
        isPlaying = true;
        Color color = gameoverImage.color;
        Color color1 = button.color;
        time = 0f;
        color.a = Mathf.Lerp(start, end, time);
        color1.a = Mathf.Lerp(start, end, time);
        while (color.a < 1f)
        {
            time += Time.deltaTime / FadeTime;
            color.a = Mathf.Lerp(start, end, time);
            color1.a = Mathf.Lerp(start, end, time);
            gameoverImage.color = color;
            button.color = color1;
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
    public void GoMain()
    {
        int talkId = StoryManager.Setup(dungeonType,floorHeight);
        Debug.Log(dungeonType +"/"+floorHeight);
        if(isFirstClear && talkManager.TalkData.ContainsKey(talkId)) SceneManager.LoadScene("Story");
        else SceneManager.LoadScene("Main");
    }
}
