using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UIPopup : MonoBehaviour
{
    public static UIPopup instance;
    public bool isOpen = false;
    Image selectedBtnImage;
    [SerializeField] GameObject btnPrefap;
    [SerializeField] ColorStatusPrefap[] colorBodyPrefap;
    [SerializeField] ColorStatusPrefap[] colorLeftPrefap;
    [SerializeField] ColorStatusPrefap[] colorRightPrefap;
    [SerializeField] ColorStatusPrefap[] weaponPrefap;
    List<GameObject> btnList;
    Dictionary<string, List<GameObject>> btnDict = new Dictionary<string, List<GameObject>>();
    [SerializeField] GameObject contents;
    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;

    }
    void Start()
    {
        InitBtn(colorBodyPrefap, "Body");
        InitBtn(colorLeftPrefap, "LeftHand");
        InitBtn(colorRightPrefap, "RightHand");
        InitBtn(weaponPrefap, "Weapon");
        gameObject.SetActive(false);
    }
    void InitBtn(ColorStatusPrefap[] prefap, string target)
    {
        List<GameObject> btnList = new List<GameObject>();
        for (int i = 0; i < prefap.Length; i++)
        {
            var newBtn = Instantiate<GameObject>(this.btnPrefap, contents.transform);
            btnList.Add(newBtn);
            newBtn.GetComponent<colorSelector>().Init(prefap[i]);
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
            selectedBtnImage.sprite = EventSystem.current.currentSelectedGameObject.GetComponent<colorSelector>().Color.sprite;
            Debug.Log("Asdasd");
            ClosePopup();
        }
        else//닫혀 있으면 열으라 
        {
            gameObject.SetActive(true);
            selectedBtnImage = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Image>();
            Debug.Log(selectedBtnImage);
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
