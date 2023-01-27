using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UIPopup : MonoBehaviour
{
    public static UIPopup instance;
    public bool isOpen = false;
    [SerializeField] GameObject contents;
    [SerializeField] GameObject btnPrefap;
    List<GameObject> btnList;
    Dictionary<string, List<GameObject>> btnDict = new Dictionary<string, List<GameObject>>();
    BtnImage selectedBtn;
    ColorDatabase colorDatabase;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;

    }
    void Start()
    {
        colorDatabase = ColorDatabase.instance;
        InitBtn(colorDatabase.GetPrefaps(spriteType.body), "Body");
        InitBtn(colorDatabase.GetPrefaps(spriteType.leftHand), "LeftHand");
        InitBtn(colorDatabase.GetPrefaps(spriteType.rightHand), "RightHand");
        InitBtn(colorDatabase.GetPrefaps(spriteType.weapon), "Weapon");
        gameObject.SetActive(false);
    }
    void InitBtn(ColorStatusPrefap[] prefap, string target)
    {
        List<GameObject> btnList = new List<GameObject>();
        for (int i = 0; i < prefap.Length; i++)
        {
            var newBtn = Instantiate<GameObject>(this.btnPrefap, contents.transform);
            btnList.Add(newBtn);
            newBtn.GetComponent<ColorSelector>().Init(prefap[i]);
            newBtn.SetActive(false);
        }
        btnDict.Add(target, btnList);
    }
    public void ActivatePopup()
    {
        string selectedBtnName = EventSystem.current.currentSelectedGameObject.name;
        //Debug.Log(selectedBtnName);
        if (isOpen)//열려 있으면 닫으라
        {
            selectedBtn.ChangePortrait(EventSystem.current.currentSelectedGameObject.GetComponent<ColorSelector>().Color.sprite);
            ClosePopup();
        }
        else//닫혀 있으면 열으라 
        {
            gameObject.SetActive(true);
            selectedBtn = EventSystem.current.currentSelectedGameObject.GetComponent<BtnImage>();
            ActivateBtn(selectedBtnName);
            isOpen = !isOpen;
        }
    }
    void ActivateBtn(string activatedName)
    {
        foreach(KeyValuePair<string, List<GameObject>> entry in btnDict)
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
