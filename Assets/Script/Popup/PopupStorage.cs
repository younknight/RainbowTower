using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PopupStorage : MonoBehaviour
{
    [SerializeField] EquipmentPrefap equipmentPrefap;//
    [SerializeField] Item item;//

    [SerializeField] Image portrait;
    [SerializeField] TextMeshProUGUI attack;
    [SerializeField] TextMeshProUGUI defence;
    [SerializeField] TextMeshProUGUI criRate;
    [SerializeField] TextMeshProUGUI criDamage;
    [SerializeField] TextMeshProUGUI hp;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI explain;
    [SerializeField] TextMeshProUGUI type;
    [SerializeField] TextMeshProUGUI objName;
    TextChanger textChanger = new TextChanger();
    Dictionary<status, TextMeshProUGUI> texts = new Dictionary<status, TextMeshProUGUI>();

    public Item Item { get => item; set => item = value; }
    public EquipmentPrefap EquipmentPrefap { get => equipmentPrefap; set => equipmentPrefap = value; }
    private void Start()
    {
        texts.Add(status.attackDamage, attack);
        texts.Add(status.defence, defence);
        texts.Add(status.criticalRate, criRate);
        texts.Add(status.criticalDamage, criDamage);
        texts.Add(status.hp, hp);
        gameObject.SetActive(false);
    }
    public void Setup(bool isItem)
    {
        if (isItem)
        {
            portrait.sprite = item.sprite;
            objName.text = item.itemName;
            foreach (KeyValuePair<status,TextMeshProUGUI> entry in texts)
            {
                entry.Value.text = "0";
            }
            for (int i = 0; i < item.targetState.Length; i++)
            {
                if (item.itemType[i] == ItemType.LevelUP || item.itemType[i] == ItemType.Heal)
                {
                    texts[item.targetState[i]].text = "" + item.value[i];
                }
            }
            int level = 1;
            Item copy = item;
            while(copy.nextItem != null)
            {
                copy = copy.nextItem;
                level++;
            }
            levelText.transform.parent.gameObject.SetActive(true);
            levelText.text = ""+level;
            string str = textChanger.ExplainChangeInShop(item);
            explain.text = str;
            type.text = item.itemClass.ToString();
        }
        else
        {
            portrait.sprite = equipmentPrefap.sprite;
            objName.text = equipmentPrefap.equipmentName;
            texts[status.hp].text = "" + equipmentPrefap.hp;
            texts[status.defence].text = "" + equipmentPrefap.defence;
            texts[status.attackDamage].text = "" + equipmentPrefap.attackDamage;
            texts[status.criticalRate].text = "" + equipmentPrefap.criticalRate;
            texts[status.criticalDamage].text = "" + equipmentPrefap.criticalDamage;
            levelText.transform.parent.gameObject.SetActive(false);
            explain.text = equipmentPrefap.explain;
            type.text = equipmentPrefap.spriteTarget.ToString();
        }
    }
}
