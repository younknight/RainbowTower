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
        //id = 1000 프롤로그, 1100 = 튜토리얼 메인, 1200 = 튜토리얼 전투
        talkData.Add(1000, new Talk(speakerType.상점아저씨, "어서오는 데스"));
        talkData.Add(1001, new Talk(speakerType.상점아저씨, "일단 집으로 가자 데스"));
        //-----------------------------------------------------------------------------------------------------------------------
        talkData.Add(1100, new Talk(speakerType.상점아저씨, "여기가 집이다 데스"));
        talkData.Add(1101, new Talk(speakerType.상점아저씨, "먼저 지금 보이는 버튼이 집밖으로 나가는 버튼데스"));
        talkData.Add(1102, new Talk(speakerType.상점아저씨, "다음은 너의 장비와\n아이템에 관해서 데스"));
        talkData.Add(1103, new Talk(speakerType.상점아저씨, "여기서 너의 장비를\n바꿀수 있데스"));
        talkData.Add(1104, new Talk(speakerType.상점아저씨, "장비를 바꾸면\n너의 신체능력이 바뀐데스"));
        talkData.Add(1105, new Talk(speakerType.상점아저씨, "이거는 아이템을\n바꾸는 영역데스"));
        talkData.Add(1106, new Talk(speakerType.상점아저씨, "각 색깔별로 들고\n갈수 있는 아이템이\n다르데스"));
        talkData.Add(1107, new Talk(speakerType.상점아저씨, "각 아이템의 효과는\n이 창고에서\n확인 할 수 있데스"));
        talkData.Add(1108, new Talk(speakerType.상점아저씨, "마지막으로 나의 상점을 보여주겠데스"));
        talkData.Add(1109, new Talk(speakerType.상점아저씨, "여기서는 돈과 물감을 내고\n각종 물건을살 수 있데스"));
        talkData.Add(1110, new Talk(speakerType.상점아저씨, "아이템은 골드만으로\n살 수 있데스"));
        talkData.Add(1111, new Talk(speakerType.상점아저씨, "장비는 골드와 물감이\n필요하데스"));
        talkData.Add(1112, new Talk(speakerType.상점아저씨, "골드와 물감은 적을\n무찌르면 얻을 수 있데스"));
        talkData.Add(1113, new Talk(speakerType.상점아저씨, "이걸로 끝데스"));
        //-----------------------------------------------------------------------------------------------------------------------
        talkData.Add(1200, new Talk(speakerType.상점아저씨, "그럼 이제 탑에서 싸우는 법에 대해서 알려주겠데스"));
        //id = 2000 레드타워

        talkData.Add(2000, new Talk(speakerType.상점아저씨, "1층 클리어 축하 한다 데스"));
        //id = 3000 오렌지타워
        //...
    }
}
