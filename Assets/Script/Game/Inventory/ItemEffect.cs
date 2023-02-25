using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemEffect : MonoBehaviour
{
    public static ItemEffect instance;
    UnitState playerStatus;
    List<IEnumerator> coroutines = new List<IEnumerator>();
    Dictionary<ItemType, List<IEnumerator>> usedItemList = new Dictionary<ItemType, List<IEnumerator>>();
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        playerStatus = GameObject.FindWithTag("Player").GetComponent<UnitState>();
        usedItemList.Add(ItemType.Heal, new List<IEnumerator>());

    }
    public void UseItem(Item item)
    {
        for (int index = 0; index < item.itemType.Length; index++)
        {
            switch (item.itemType[index])
            {
                case ItemType.LevelUP:
                    playerStatus.StatusChange(item.targetState[index], item.value[index], true);
                    break;
                case ItemType.Heal:
                    IEnumerator coroutine = Heal(item, index);
                    StartCoroutine(coroutine);
                    usedItemList[ItemType.Heal].Add(coroutine);
                    break;
            }
        }
        return;
    }
    public void EndItem(Item item)
    {
        for (int index = 0; index < item.itemType.Length; index++)
        {
            switch (item.itemType[index])
            {
                case ItemType.LevelUP:
                    playerStatus.StatusChange(item.targetState[index], item.value[index], false);
                    break;
                case ItemType.Heal:
                    StopCoroutine(usedItemList[ItemType.Heal][0]);
                    usedItemList[ItemType.Heal].RemoveAt(0);
                    break;
            }
        }
    }
    public IEnumerator Heal(Item item, int index)
    {
        while (true)
        {
            playerStatus.Heal(item.value[index]);
            yield return new WaitForSeconds(item.coolTime[index]);
        }
    }
}