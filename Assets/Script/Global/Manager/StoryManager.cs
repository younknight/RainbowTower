using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class StoryManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI charName;
    [SerializeField] TypeEffect talk;
    TalkDatabase talkManager = new TalkDatabase();
    static int talkId = 1000;
    int index = 0;
    private void Start()
    {
        NextText();
    }
    public static int Setup(DungeonType dungeonType,int floor)
    {
        switch (dungeonType)
        {
            case DungeonType.redTower:
                talkId = 2000;
                break;
            case DungeonType.orangeTower:
                talkId = 3000;
                break;
            case DungeonType.yellowTower:
                talkId = 4000;
                break;
            case DungeonType.greenTower:
                talkId = 5000;
                break;
            case DungeonType.blueTower:
                talkId = 6000;
                break;
            case DungeonType.purpleTower:
                talkId = 7000;
                break;
        }
        talkId += floor * 100;
        return talkId;
    }
    public void NextText()
    {
        if (talkManager.TalkData.ContainsKey(talkId + index))
        {
            charName.text = talkManager.TalkData[talkId + index].GetSpeaker().ToString();
            talk.Setup(talkManager.TalkData[talkId + index].GetTalk());
            index++;
            return;
        }
        EndTalk();
    }
    public void EndTalk()
    {
        if(talkId == 1000) DataManager.DataPlayer.clearedStory[1] = true;
        DataManager.instance.Save();
        SceneManager.LoadScene("Main");
    }
}
