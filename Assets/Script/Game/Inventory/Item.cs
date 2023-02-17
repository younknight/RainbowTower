using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="NewItem", menuName = "NewItem/item")]
public class Item : ScriptableObject
{
    public status targetState; //작용할 스테이터스
    public ItemType itemType; //아이템 타입
    public Sprite sprite; //초상화
    public string itemName;//이름
    public string explain; //설명
    public int itemIndex; //아이템 번호
    public int duration; //지속시간
    public double value;
}
