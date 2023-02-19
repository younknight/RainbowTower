using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="NewItem", menuName = "NewItem/item")]
public class Item : ScriptableObject
{
    //아이템 정보
    public Sprite sprite; //초상화
    public colorType colorType;
    public ItemClass itemClass;
    public string itemName;//이름
    public string explain; //설명
    //아이템 강화
    public int level;
    public float enforce;
    public int cost;
    public Item nextItem;
    //아이템 효과
    public ItemType[] itemType; //아이템 타입
    public status[] targetState; //작용할 스테이터스
    public float[] value;
    public float[] coolTime;
}