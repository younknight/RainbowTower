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
        Show();
    }
    public void EnforceItem()
    {
        if (Inventory.Instance.Sp >= item.cost)
        {
            if (Random.Range(0, 100) <= item.enforce)
            {
                Debug.Log("강화 성공");
                slot.AddItem(item.nextItem);
                Setup(slot);
            }
            else Debug.Log("강화 실패");
            Inventory.Instance.GetSp(-(item.cost));
        }
    }
    /////
    void Show()
    {
        //Debug.Log("해당 아이템의 링크 수 = " +Slot.Graph[colorType.red].BFS(slot.index));
    }
}
