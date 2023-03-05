using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum speakerType
{
    나레이터,
    플레이어,
    상점아저씨
}
public class Talk
{
    speakerType speakerType;
    string talk;
    public Talk(speakerType speakerType, string talk)
    {
        this.speakerType = speakerType;
        this.talk = talk;
    }
    public string GetTalk()
    {
        return talk;
    }
    public speakerType GetSpeaker()
    {
        return speakerType;
    }
}
public class TalkManager
{
    Dictionary<int, Talk> talkData;
    public Dictionary<int, Talk> TalkData { get => talkData; }
    public TalkManager()
    {
        talkData = new Dictionary<int, Talk>();
        GenerateShopData();
        GenerateStroyData();
    }
    void GenerateShopData()
    {
        talkData.Add(0000, new Talk(speakerType.상점아저씨, "여기는 상점 데스"));
        talkData.Add(0001, new Talk(speakerType.상점아저씨, "구매 고맙다 데스"));
        talkData.Add(0002, new Talk(speakerType.상점아저씨, "그거 좋다 데스"));
        talkData.Add(0003, new Talk(speakerType.상점아저씨, "아쉽다 데스"));
        talkData.Add(0004, new Talk(speakerType.상점아저씨, "돈이 부족하다 데스"));
    }
    void GenerateStroyData()
    {
        //id => 1000 = 타워, 0100 = 층수
        //id = 1000 튜토리얼
        talkData.Add(1000, new Talk(speakerType.상점아저씨, "어서오는 데스"));
        talkData.Add(1001, new Talk(speakerType.상점아저씨, "여기는 상점 데스"));
        talkData.Add(1002, new Talk(speakerType.상점아저씨, "여기는 상점 데스"));
        talkData.Add(1003, new Talk(speakerType.상점아저씨, "여기는 상점 데스"));
        talkData.Add(1004, new Talk(speakerType.상점아저씨, "여기는 상점 데스"));
        talkData.Add(1005, new Talk(speakerType.상점아저씨, "여기는 상점 데스"));
        talkData.Add(1006, new Talk(speakerType.상점아저씨, "여기는 상점 데스"));
        talkData.Add(1007, new Talk(speakerType.상점아저씨, "여기는 상점 데스"));
        talkData.Add(1008, new Talk(speakerType.상점아저씨, "여기는 상점 데스"));
        talkData.Add(1009, new Talk(speakerType.상점아저씨, "여기는 상점 데스"));
        talkData.Add(1010, new Talk(speakerType.상점아저씨, "여기는 상점 데스"));
        talkData.Add(1011, new Talk(speakerType.상점아저씨, "여기는 상점 데스"));
        talkData.Add(1012, new Talk(speakerType.상점아저씨, "여기는 상점 데스"));
        talkData.Add(1013, new Talk(speakerType.상점아저씨, "끝났다 데스"));
        //id = 2000 레드타워

        talkData.Add(2000, new Talk(speakerType.상점아저씨, "1층 클리어 축하 한다 데스"));
        //id = 3000 오렌지타워
        //...
    }
}
