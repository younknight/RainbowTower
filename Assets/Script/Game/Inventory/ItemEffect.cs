using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemEffect : MonoBehaviour
{
    public static ItemEffect instance;
    UnitState playerStatus;
    LinkCalculator linkCalculator = new LinkCalculator();
    Dictionary<ItemType, List<IEnumerator>> usedDelayItemList = new Dictionary<ItemType, List<IEnumerator>>();
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        playerStatus = GameObject.FindWithTag("Player").GetComponent<UnitState>();
        //delayItem
        usedDelayItemList.Add(ItemType.Heal, new List<IEnumerator>());
    }
    public void UseItem(int index,Item item, int link)
    {
        float plus = linkCalculator.LinkDamageCalculater(item.linkType, link);
        switch (item.itemType[index])
        {
            case ItemType.LevelUP:
                playerStatus.StatusChange(item.targetState[index], item.value[index] + plus, true);
                break;
            case ItemType.Heal:
                IEnumerator coroutine = Heal(index, item, plus);
                StartCoroutine(coroutine);
                usedDelayItemList[ItemType.Heal].Add(coroutine);
                break;
        }
        return;
    }
    public void EndItem(int index, Item item, int link)
    {
        float plus = linkCalculator.LinkDamageCalculater(item.linkType, link);
        switch (item.itemType[index])
        {
            case ItemType.LevelUP:
                playerStatus.StatusChange(item.targetState[index], item.value[index] + plus, false);
                break;
            case ItemType.Heal:
                StopCoroutine(usedDelayItemList[ItemType.Heal][0]);
                usedDelayItemList[ItemType.Heal].RemoveAt(0);
                break;
        }
    }
    public IEnumerator Heal(int index, Item item, float plus)
    {
        while (true)
        {
            yield return new WaitForSeconds(item.coolTime[index]);
            Debug.Log("healed");
            playerStatus.Heal(item.value[index]);
        }
    }
}