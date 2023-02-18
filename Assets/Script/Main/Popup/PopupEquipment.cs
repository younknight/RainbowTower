using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PopupEquipment : MonoBehaviour
{
    [SerializeField] GameObject contents;//생성될 위치
    [SerializeField] GameObject btnPrefap;//생성할 버튼
    List<GameObject> btnList;//생성된 버튼 리스트
    Dictionary<equipment, List<GameObject>> btnDict = new Dictionary<equipment, List<GameObject>>();
    Database colorDatabase;
    ButtonManager selectedBtn;
    Data playerData;
    void Awake()
    {
        playerData = DataManager.Data;
        colorDatabase = Database.instance;
        InitBtn(colorDatabase.GetPrefaps(equipment.body), equipment.body);
        InitBtn(colorDatabase.GetPrefaps(equipment.leftHand), equipment.leftHand);
        InitBtn(colorDatabase.GetPrefaps(equipment.rightHand), equipment.rightHand);
        InitBtn(colorDatabase.GetPrefaps(equipment.weapon), equipment.weapon);
    }
    void InitBtn(EqujpmentPrefap[] prefap, equipment equipment)//버튼들 초기화하기
    {
        List<GameObject> btnList = new List<GameObject>();
        for (int i = 0; i < playerData.equipment[equipment].hasEquipment.Count; i++)
        {
            if (playerData.equipment[equipment].hasEquipment[i])
            {
                var newBtn = Instantiate<GameObject>(this.btnPrefap, contents.transform);
                btnList.Add(newBtn);
                newBtn.GetComponent<EquipmentSelector>().InitalizeButton(prefap[i]);
                newBtn.SetActive(false);
            }
        }
        btnDict.Add(equipment, btnList);
    }
    public void ActivatePopup()//껐다 켜기
    {
        foreach (KeyValuePair<equipment, List<GameObject>> entry in btnDict)
        {
           // Debug.Log("sbk:" + ButtonManager.SelectedBtn.GetComponent<ButtonManager>().EquipmentType + "entk:" + entry.Key);

            if (entry.Key == ButtonManager.SelectedBtn.GetComponent<ButtonManager>().EquipmentType)
            {
                foreach (var btn in entry.Value)
                {
                    btn.SetActive(true);
                }
            }
            else
            {
                foreach (var btn in entry.Value)
                {
                    btn.SetActive(false);
                }
            }
        }
    }
}
