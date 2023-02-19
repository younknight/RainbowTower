using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemSelector : MonoBehaviour
{
    Item itemPrefap;
    Popup popup;
    private void Start()
    {
        popup = GameObject.Find("InventoryPopup").GetComponent<Popup>();
    }
    public void InitalizeButton(Item itemPrefap)//버튼의 정보와 이미지 초기화
    {
        this.itemPrefap = itemPrefap;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = itemPrefap.sprite;
    }
    public void AddItem()
    {
        if (!PlayerManager.PlayerItem.Contains(itemPrefap))
        {
            DeleteItem();
            ButtonManager selectedBtn = ButtonManager.SelectedBtn.GetComponent<ButtonManager>();
            selectedBtn.ChangePortrait(itemPrefap.sprite);
            Color color = selectedBtn.transform.GetChild(0).GetComponent<Image>().color;
            color.a = 1f;
            selectedBtn.transform.GetChild(0).GetComponent<Image>().color = color;
            selectedBtn.Item = itemPrefap;
            PlayerManager.PlayerItem.Add(itemPrefap);
        }
        popup.ClosePopup();
    }
    public void DeleteItem()
    {
        ButtonManager selectedBtn = ButtonManager.SelectedBtn.GetComponent<ButtonManager>();
        Color color = selectedBtn.transform.GetChild(0).GetComponent<Image>().color;
        color.a = 0f;
        selectedBtn.transform.GetChild(0).GetComponent<Image>().color = color;
        PlayerManager.PlayerItem.Remove(selectedBtn.Item);
        popup.ClosePopup();
    }
}
