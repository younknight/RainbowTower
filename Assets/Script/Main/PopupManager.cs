using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PopupManager : MonoBehaviour
{
    public static PopupManager instance;
    public bool isOpen = false;
    [SerializeField] GameObject contents;
    [SerializeField] GameObject btnPrefap;
    List<GameObject> btnList;
    Dictionary<equipment, List<GameObject>> btnDict = new Dictionary<equipment, List<GameObject>>();
    ButtonManager selectedBtn;
    ColorDatabase colorDatabase;
    Data playerData;
    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        playerData = DataManager.Data;
    }
    void Start()
    {
        colorDatabase = ColorDatabase.instance;
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
                newBtn.GetComponent<ColorSelector>().InitalizeButton(prefap[i]);
                newBtn.SetActive(false);
            }
        }
        btnDict.Add(equipment, btnList);
    }
    public void ActivatePopup()//���� �ѱ�
    {
        if (isOpen)//���� ������ ������
        {
            selectedBtn.ChangePortrait(EventSystem.current.currentSelectedGameObject.GetComponent<ColorSelector>().Color.sprite);
            ClosePopup();
        }
        else//���� ������ ������ 
        {
            gameObject.SetActive(true);
            selectedBtn = EventSystem.current.currentSelectedGameObject.GetComponent<ButtonManager>();
            equipment selectedBtnType = selectedBtn.GetComponent<ButtonManager>().EquipmentType;
            ActivateBtn(selectedBtnType);
            isOpen = !isOpen;
        }
    }
    void ActivateBtn(equipment activatedName)// ���õ� ��ư�� ������ ���õ� ��ư�鸸 Ȱ��ȭ
    {
        foreach(KeyValuePair<equipment, List<GameObject>> entry in btnDict)
        {
            if(entry.Key == activatedName)
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
    public void ClosePopup()
    {
        isOpen = false;
        gameObject.SetActive(false);
    }
}
