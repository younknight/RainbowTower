using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TutorialManager : MonoBehaviour
{
    [SerializeField] GameObject tutorial;//튜토리얼
    [SerializeField] GameObject talkUp;
    TextMeshProUGUI talkupText;
    [SerializeField] GameObject talkDown;
    TextMeshProUGUI talkdownText;
    [SerializeField] GameObject targetSelector;

    [SerializeField] SnapScroll snapScroll;//칸 이동용
    Data data;
    void Start()
    {
        data = DataManager.Data;
        if (!data.clearedStory[0])//튜토리얼 시작
        {
            if(!data.clearedStory[1]) SceneManager.LoadScene("Story");
            DoTutorial();
            return;
        }
        tutorial.SetActive(false);
    }
    public void DoTutorial()
    {
        targetSelector.SetActive(false);
        talkupText = talkUp.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        talkdownText = talkDown.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        talkUp.SetActive(false);
    }

}
