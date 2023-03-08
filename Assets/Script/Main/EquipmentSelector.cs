using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSelector : MonoBehaviour
{
    EquipmentPrefap equipmentPrefap;//가지고 있는 색깔정보
    Popup popup;

    public EquipmentPrefap EquipmentPrefap { get => equipmentPrefap; set => equipmentPrefap = value; }

    private void Start()
    {
        if(GameObject.Find("EquipmentPopup") != null) popup = GameObject.Find("EquipmentPopup").GetComponent<Popup>();
    }
    public void InitalizeButton(EquipmentPrefap colorStatusPrefap)//버튼의 정보와 이미지 초기화
    {
        equipmentPrefap = colorStatusPrefap;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = equipmentPrefap.sprite;
    }
    public void ChangeEquipment()//색깔 바꾸기
    {
        PlayerManager.ChangeEquipment(equipmentPrefap.spriteTarget, equipmentPrefap); //플레이어 정보저장
        StatusManager.Instance.SetStatus(); //스테이터스 정보 표시
        DataManager.SetEquipmentData(equipmentPrefap.spriteTarget, equipmentPrefap.index);//데이터 저장
        popup.ClosePopup();
        ButtonManager.SelectedBtn.GetComponent<ButtonManager>().ChangePortrait(equipmentPrefap.sprite);
    }
}