using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PopupItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemOfName;
    [SerializeField] TextMeshProUGUI explain;
    [SerializeField] TextMeshProUGUI enforce;
    [SerializeField] TextMeshProUGUI cost;
    [SerializeField] Image portrait;
    Slot slot;
    Item item;
    public Slot Slot { get => slot; set => slot = value; }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void Setup(Slot slot)
    {
        this.slot = slot;
        this.item = slot.item;
        itemOfName.text = item.itemName;
        string str = item.explain;
        for(int index = 0; index < item.itemType.Length;index++)
        {
            //Debug.Log(index);
            str = str.Replace("@Cool" + (index + 1), "<color=red>" + item.coolTime[index] + "</color>");
            str = str.Replace("@Value" + (index + 1), "<color=red>" + item.value[index] + "</color>");
            str = str.Replace("@Link","<color=blue>" + Slot.Graph[item.colorType].BFS(slot.index) + "</color>");
        }
        explain.text = str;
        enforce.text = "" + item.enforce;
        cost.text = "" + item.cost;
        portrait.sprite = item.sprite;
    }
    public void EnforceItem()
    {
        if (Inventory.Instance.Sp >= item.cost)
        {
            if (Random.Range(0, 100) <= item.enforce)
            {
                for (int index = 0; index < item.itemType.Length; index++)
                {
                    ItemEffect.instance.EndItem(index, item, slot.LinkedItemNum);
                }
                slot.AddItem(item.nextItem);
                for (int index = 0; index < item.nextItem.itemType.Length; index++)
                {
                    ItemEffect.instance.UseItem(index, item.nextItem, slot.LinkedItemNum);
                }
                Setup(slot);
            }
            Inventory.Instance.GetSp(-(item.cost));
        }
    }
}
