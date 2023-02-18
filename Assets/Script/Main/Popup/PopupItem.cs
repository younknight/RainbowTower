using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PopupItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemOfName;
    [SerializeField] TextMeshProUGUI explain;
    [SerializeField] Image portrait;
    Item item;
    public void Setup(Item item)
    {
        this.item = item;
        itemOfName.text = item.itemName;
        explain.text = item.explain;
        portrait.sprite = item.sprite;
    }
}
