using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PopupItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI explain;
    [SerializeField] Image portrait;
    public void Setup(Item item)
    {
        name.text = item.itemName;
        explain.text = item.explain;
        portrait.sprite = item.sprite;
    }
}
