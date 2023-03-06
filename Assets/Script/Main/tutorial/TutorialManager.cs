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
    TextMeshProUGUI talkText;
    [SerializeField] GameObject targetSelector;
    RectTransform rectTransform;
    [SerializeField] SnapScroll snapScrollMain;//칸 이동용
    [SerializeField] SnapScroll snapScrollShop;//칸 이동용
    Data data;
    TalkManager talkManager = new TalkManager();
    int index = 0;
    bool haveToWait = false;
    void Start()
    {
        data = DataManager.Data;
        
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
        talkText = talkFrame.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        talkText.text = talkManager.TalkData[1100 + index].GetTalk();
        index++;
        targetSelector.SetActive(false);
    }
    public void EndTutorial()
    {
        tutorial.SetActive(false);
        data.clearedStory[0] = true;
    }
    public void NextTutorial()
    {
        targetSelector.SetActive(false);
        if (!haveToWait)
        {
            haveToWait = true;
            if (!talkManager.TalkData.ContainsKey(1100 + index))
            {
                tutorial.SetActive(false);
                data.clearedStory[0] = true;
                snapScrollMain.NextSnap(0);
                snapScrollShop.NextSnap(0);
                return;
            }
            switch (index)
            {
                case 1:
                    targetSelector.SetActive(true);
                    break;
                case 2:
                    snapScrollMain.NextSnap(0);
                    break;
                case 3:
                    targetSelector.SetActive(true);
                    SetTargetSelector(0, 15, 245, 215);
                    break;
                case 5:
                    targetSelector.SetActive(true);
                    SetTargetSelector(0, -175, 240, 140);
                    break;
                case 7:
                    snapScrollMain.NextSnap(0);
                    break;
                case 8:
                    snapScrollMain.PreviousSnap(2);
                    break;
                case 10:
                    targetSelector.SetActive(true);
                    SetTargetSelector(-80, 55, 80, 120);
                    break;
                case 11:
                    snapScrollShop.PreviousSnap(0);
                    StartCoroutine(DelayWhithActive(0.5f));
                    break;
            }
            talkText.text = talkManager.TalkData[1100 + index].GetTalk();
            index++;
            StartCoroutine(Delay(0.5f));
        }
    }
    void SetTargetSelector(int x, int y, int width, int height)
    {
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
    IEnumerator DelayWhithActive(float time)
    {
        yield return new WaitForSeconds(time);
        targetSelector.SetActive(true);
        SetTargetSelector(0, 75, 240, 80);
    }
}
