using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemSelector : MonoBehaviour
{
    Item itemPrefap;
    public void InitalizeButton(Item itemPrefap)//��ư�� ������ �̹��� �ʱ�ȭ
    {
        this.itemPrefap = itemPrefap;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = itemPrefap.sprite;
    }
    public void AddItem()
    {
        foreach(Item item in PlayerManager.playerItem)
        {
            Debug.Log(item.itemIndex + "" + item.itemName);
        }
        if (!PlayerManager.playerItem.Contains(itemPrefap))
        {
            DeleteItem();
            ButtonManager selectedBtn = ButtonManager.SelectedBtn.GetComponent<ButtonManager>();
            selectedBtn.ChangePortrait(itemPrefap.sprite);
            Color color = selectedBtn.transform.GetChild(0).GetComponent<Image>().color;
            color.a = 1f;
            selectedBtn.transform.GetChild(0).GetComponent<Image>().color = color;
            selectedBtn.Item = itemPrefap;
            selectedBtn.SetNum(DataManager.Data.hasItem[itemPrefap.itemIndex]);
            PlayerManager.playerItem.Add(itemPrefap);
        }
        Popup.ClosePopup();
    }
    public void DeleteItem()
    {
        ButtonManager selectedBtn = ButtonManager.SelectedBtn.GetComponent<ButtonManager>();
        Color color = selectedBtn.transform.GetChild(0).GetComponent<Image>().color;
        color.a = 0f;
        selectedBtn.transform.GetChild(0).GetComponent<Image>().color = color;
        PlayerManager.playerItem.Remove(selectedBtn.Item);
        selectedBtn.SetNum(0);
        Popup.ClosePopup();
    }
}
