using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PopupEquipment : MonoBehaviour
{
    [SerializeField] GameObject contents;//������ ��ġ
    [SerializeField] GameObject btnPrefap;//������ ��ư
    List<GameObject> btnList;//������ ��ư ����Ʈ
    Dictionary<equipment, List<GameObject>> btnDict = new Dictionary<equipment, List<GameObject>>();
    Database colorDatabase;
    ButtonManager selectedBtn;
    Data playerData;
    void Start()
    {
        playerData = DataManager.Data;
        colorDatabase = Database.instance;
        InitBtn(colorDatabase.GetPrefaps(equipment.body), equipment.body);
        InitBtn(colorDatabase.GetPrefaps(equipment.leftHand), equipment.leftHand);
        InitBtn(colorDatabase.GetPrefaps(equipment.rightHand), equipment.rightHand);
        InitBtn(colorDatabase.GetPrefaps(equipment.weapon), equipment.weapon);
        gameObject.SetActive(false);
    }
    void InitBtn(ColorStatusPrefap[] prefap, equipment equipment)//��ư�� �ʱ�ȭ�ϱ�
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
    public void ActivatePopup()//���� �ѱ�
    {
        if (Popup.isOpen)
        {
            foreach (KeyValuePair<equipment, List<GameObject>> entry in btnDict)
            {
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
}
