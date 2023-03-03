using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MapSelector : MonoBehaviour
{
    [SerializeField] List<EnemyListPrefap> thisEnemyList;
    Popup popupTower;
    Popup popupTown;
    PopupSelectMap popupSelectMap;
    PopupTown popupSelectTown;
    float interval = 0.25f;
    float doubleClickedTime = -1.0f;
    bool isDoubleClicked = false;

    static List<GameObject> enemyList = new List<GameObject>();
    public static List<GameObject> EnemyList { get => enemyList; set => enemyList = value; }

    private void Awake()
    {
        var popup = GameObject.Find("Popup");
        var popupT = popup.transform.GetChild(0);
        popupTower = popupT.GetComponent<Popup>();
        popupSelectMap = popupT.GetComponent<PopupSelectMap>();
        popupTown = popup.transform.GetChild(1).GetComponent<Popup>();
        popupSelectTown = popup.transform.GetChild(1).GetComponent<PopupTown>();
    }
    void Update()
    {
        if (isDoubleClicked)
        {
            OpenPopup();
            isDoubleClicked = false;
        }
    }
    private void OnMouseUp()
    {
        if ((Time.time - doubleClickedTime) < interval)
        {
            isDoubleClicked = true;
            doubleClickedTime = -1.0f;
        }
        else
        {
            isDoubleClicked = false;
            doubleClickedTime = Time.time;
        }
    }
    private void OpenPopup()
    {
        if (transform.name == "Home")
        {
            popupSelectTown.Setup(TownType.Home);
            popupTown.TogglePopup();
            return;
        }
        if (transform.name == "Shop")
        {
            popupSelectTown.Setup(TownType.Shop);
            popupTown.TogglePopup();
            return;
        }
        if (thisEnemyList != null)
        {
            popupSelectMap.Setup(thisEnemyList, gameObject.name);
            popupTower.TogglePopup();
        }
    }
}
