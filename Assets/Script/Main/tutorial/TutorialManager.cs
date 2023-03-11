using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject tutorial;//튜토리얼
    [SerializeField] GameObject talkFrame;
    [SerializeField] GameObject pannel;
    TypeEffect talkText;
    [SerializeField] GameObject targetSelector;
    RectTransform rectTransform;
    [SerializeField] SnapScroll snapScrollMain;//칸 이동용
    [SerializeField] SnapScroll snapScrollShop;//칸 이동용
    DataPlayer data;
    TalkDatabase talkManager = new TalkDatabase();
    int index = 0;
    bool haveToWait = false;
    bool waitForClick = false;
    void Start()
    {
        data = DataManager.DataPlayer;
        
        if (!data.clearedStory[0])//튜토리얼 시작
        {
            if(!data.clearedStory[1]) SceneManager.LoadScene("Story");
            DoTutorialInMain();
            return;
        }
        tutorial.SetActive(false);
    }
    public void DoTutorialInMain()
    {
        rectTransform = targetSelector.GetComponent<RectTransform>();
        talkText = talkFrame.GetComponent<TypeEffect>();
        talkText.Setup(talkManager.TalkData[1100 + index].GetTalk());
        index++;
        targetSelector.SetActive(false);
    }
    public void EndTutorial()
    {
        tutorial.SetActive(false);
        data.clearedStory[0] = true;
        DataManager.instance.Save();
    }
    public void NextTutorial()
    {
        if (!haveToWait && !waitForClick)
        {
            targetSelector.SetActive(false);
            haveToWait = true;
            if (!talkManager.TalkData.ContainsKey(1100 + index))
            {
                EndTutorial();
                return;
            }
            switch (index)
            {
                case 1:
                    SetTargetSelector(0, -64, 200, 150);
                    break;
                case 2:
                    snapScrollMain.NextSnap(0);
                    break;
                case 3:
                    SetTargetSelector(0, 15, 245, 215);
                    break;
                case 5:
                    SetTargetSelector(0, -175, 240, 140);
                    break;
                case 7:
                    snapScrollMain.NextSnap(0);
                    break;
                case 8:
                    snapScrollMain.PreviousSnap(2);
                    break;
                case 10:
                    SetTargetSelector(-80, 55, 80, 120);
                    break;
                case 11:
                    snapScrollShop.PreviousSnap(0);
                    StartCoroutine(DelayWhithActive(0.5f, 0, 75, 240, 80));
                    break;
                case 14://클릭해데스
                    snapScrollMain.NextSnap(0);
                    snapScrollShop.NextSnap(0);
                    waitForClick = true;
                    SetTargetSelector(0, -64, 200, 150);
                    StartCoroutine(DelayWithClickEvent());
                    break;
                case 15:
                    waitForClick = true;
                    StartCoroutine(DelayWhithActive(0.5f, 0, -219, 240, 80));
                    break;
            }
            talkText.Setup(talkManager.TalkData[1100 + index].GetTalk());
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
        rectTransform.sizeDelta = new Vector2(width, height);

    }
    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);
        haveToWait = false;
    }
    IEnumerator DelayWithClickEvent()
    {
        pannel.SetActive(false);
        snapScrollMain.gameObject.GetComponent<ScrollRectEx>().enabled = false;
        while (MapSelect.IsMain)
        {
            yield return new WaitForFixedUpdate();
        }
        waitForClick = false;
        NextTutorial();
        snapScrollMain.gameObject.GetComponent<ScrollRectEx>().enabled = true;
        pannel.SetActive(true);
    }
    IEnumerator DelayWhithActive(float time, int x, int y, int width, int height)
    {
        yield return new WaitForSeconds(time);
        targetSelector.SetActive(true);
        SetTargetSelector(x, y, width, height);
    }
}
