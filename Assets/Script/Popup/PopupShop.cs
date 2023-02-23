using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PopupShop : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI gold;
    [SerializeField] TextMeshProUGUI explain;
    [SerializeField] Image portrait;
    public Item item;//
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void Setup(Item item)
    {
        this.item = item;
        string str = "";
        for (int index = 0; index < item.itemType.Length; index++)
        {
            str = item.explain.Replace("@Cool" + (index + 1), "<color=red>" + item.coolTime[index] + "</color>");
            str = str.Replace("@Value" + (index + 1), "<color=red>" + item.value[index] + "</color>");
        }
        explain.text = str;
        itemName.text = item.itemName;
        gold.text = "" + item.itemValue;
        portrait.sprite = item.sprite;
    }
}
