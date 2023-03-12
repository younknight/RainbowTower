using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTutotialManager : MonoBehaviour
{
    [SerializeField] GameObject tutorial;//튜토리얼
    [SerializeField] GameObject talkFrame;
    [SerializeField] GameObject pannel;
    [SerializeField] GameObject targetSelector;
    [SerializeField] PauseManager pauseManager;
    [SerializeField] Inventory inventory;
    [SerializeField] Popup popup;
    RectTransform targetRectTransform;
    RectTransform talkRectTransform;
    TypeEffect talkText;
    DataPlayer data;
    TalkDatabase talkManager = new TalkDatabase();
    int index = 0;
    bool haveToWait = false;
    bool waitForClick = false;
    void Start()
    {
        data = DataManager.DataPlayer;
        if (!data.clearedStory[2])//튜토리얼 시작
        {
            DoTutorialInMain();
            return;
        }
        tutorial.SetActive(false);
    }
    public void DoTutorialInMain()
    {
        pauseManager.Pause();
        targetRectTransform = targetSelector.GetComponent<RectTransform>();
        talkRectTransform = talkFrame.GetComponent<RectTransform>();
        talkText = talkFrame.GetComponent<TypeEffect>();
        talkText.Setup(talkManager.TalkData[1200 + index].GetTalk());
        index++;
        targetSelector.SetActive(false);
    }
    public void EndTutorial()
    {
        tutorial.SetActive(false);
        data.clearedStory[2] = true;
        DataManager.instance.Save();
        pauseManager.Pause();
        popup.ClosePopup();
    }
    public void NextTutorial()
    {
        if (!haveToWait && !waitForClick)
        {
            targetSelector.SetActive(false);
            haveToWait = true;
            if (!talkManager.TalkData.ContainsKey(1200 + index))
            {
                EndTutorial();
                return;
            }
            switch (index)
            {
                case 1:
                    SetTalk(false);
                    SetTargetSelector(-82,137,80,80);
                    break;
                case 2:
                    SetTargetSelector(82, 137, 80, 80);
                    break;
                case 4:
                    SetTalk(true);
                    SetTargetSelector(0, -93, 200, 200);
                    break;
                case 5:
                    SetTargetSelector(0, -230, 80, 85);
                    waitForClick = true;
                    StartCoroutine(DelayWithClickEvent(0));
                    break;
                case 6:
                    SetTargetSelector(-75, -20, 50, 50);
                    waitForClick = true;
                    StartCoroutine(DelayWithClickEvent(1));
                    break;
                case 7:
                    SetTargetSelector(65, -112, 140, 150);
                    break;
                case 8:
                    SetTargetSelector(-48, -155, 68, 65);
                    break;
            }
            talkText.Setup(talkManager.TalkData[1200 + index].GetTalk());
            index++;
            StartCoroutine(Delay(0.5f));
        }
    }
    void SetTargetSelector(int x, int y, int width, int height)
    {
        targetSelector.SetActive(true);
        Vector3 position = targetSelector.transform.localPosition;
        position.x = x;
        position.y = y;
        targetSelector.transform.localPosition = position;
        targetRectTransform.sizeDelta = new Vector2(width, height);

    }
    IEnumerator Delay(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        haveToWait = false;
    }
    IEnumerator DelayWithClickEvent(int index)
    {
        pannel.SetActive(false);
        if(index == 0)
        {
            while (inventory.slots[0].item == null)
            {
                yield return new WaitForSecondsRealtime(0.001F);
            }
        }
        if(index == 1)
        {
            while (Popup.CurrentPopup == null)
            {
                yield return new WaitForSecondsRealtime(0.001F);
            }
        }
        waitForClick = false;
        pannel.SetActive(true);
        NextTutorial();
    }
    void SetTalk(bool isUp)
    {
        Vector3 position = talkFrame.transform.localPosition;
        position.y = isUp ? 135 : -130;
        talkFrame.transform.localPosition = position;
        talkRectTransform.sizeDelta = new Vector2(308, isUp ? 155 : 280);
    }
}
