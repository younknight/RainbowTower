using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemEffectDatabase : MonoBehaviour
{
    public static ItemEffectDatabase instance;
    UnitState playerStatus;
    private void Awake()
    {
        if (instance == null) instance = this;
        playerStatus = GameObject.FindWithTag("Player").GetComponent<UnitState>();
    }
    public void UseItem(Item _item)
    {
        BuffPlayer(_item, playerStatus);
        return;
    }
    void  BuffPlayer(Item _item, UnitState player)
    {
        switch (_item.itemType)
        {
            case Item.ItemType.LevelUP:
                StartCoroutine(player.ChangeStatus(_item, true));
                break;
        }
    }
     
}