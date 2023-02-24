using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum talkType
{
    Shop
}
public class TalkManager
{
    Dictionary<talkType, List<string>> talkData;
    public TalkManager()
    {
        talkData = new Dictionary<talkType, List<string>>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(talkType.Shop, new List<string>());
        talkData[talkType.Shop].Add("여기는 상점 데스");
        talkData[talkType.Shop].Add("구매 고맙다 데스");
        talkData[talkType.Shop].Add("그거 좋다 데스");
        talkData[talkType.Shop].Add("아쉽다 데스");
    }

    public string GetTalk(talkType id, int talkIndex) //Object의 id , string배열의 index
    {
        return talkData[id][talkIndex]; //해당 아이디의 해당
    }
}
