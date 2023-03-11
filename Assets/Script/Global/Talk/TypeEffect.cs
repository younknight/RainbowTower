using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TypeEffect : MonoBehaviour
{
    [SerializeField] float CPS = 0.05f; //초마다 한글자
    TextMeshProUGUI talkText;
    string targetMsg;
    int index;
    static IEnumerator coroutine;
    private void Awake()
    {
        talkText = transform.Find("talkText").GetComponent<TextMeshProUGUI>();   
    }
    public void Setup(string msg)
    {
        targetMsg = msg;
        EffectStart();
    }
    void EffectStart()
    {
        talkText.text = "";
        index = 0;
        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = Effecting();
        StartCoroutine(coroutine);
    }
    IEnumerator Effecting()
    {
        while (talkText.text != targetMsg)
        {
            talkText.text += targetMsg[index];
            index++;
            yield return new WaitForSeconds(CPS);

        }
        EffectEnd();
    }
    void EffectEnd()
    {

    }
}
