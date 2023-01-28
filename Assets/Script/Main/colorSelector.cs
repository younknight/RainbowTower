using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour
{
    ColorStatusPrefap colorPrefap;//가지고 있는 색깔정보

    public ColorStatusPrefap Color { get => colorPrefap; }

    public void InitalizeButton(ColorStatusPrefap colorStatusPrefap)//버튼의 정보와 이미지 초기화
    {
        colorPrefap = colorStatusPrefap;
        gameObject.transform.GetChild(0).GetComponent<Image>().sprite = colorPrefap.sprite;
    }
    public void ChangeColor()//색깔 바꾸기
    {
        PlayerManager.ChangeSprite(colorPrefap.spriteTarget, colorPrefap); //플레이어 정보저장
        StatusManager.instance.SetStatus(); //스테이터스 정보 표시
        DataManager.SetEquipmentData(colorPrefap.spriteTarget, colorPrefap.index);//데이터 저장
        Debug.Log("작동됨");
        PopupManager.instance.ActivatePopup();
    }
}