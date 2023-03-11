using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class MapSelector : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI towerName;
    [SerializeField] Image towerImage;
    [SerializeField] List<FloorPrefap> thisFloorList;
    [SerializeField] DungeonType dungeonType;
    Popup popupTower;
    PopupSelectMap popupSelectMap;
    static FloorPrefap floorPrefap;
    float interval = 0.25f;
    float doubleClickedTime = -1.0f;
    bool isDoubleClicked = false;
    public static FloorPrefap FloorPrefap { get => floorPrefap; set => floorPrefap = value; }

    private void Awake()
    {
        var popup = GameObject.Find("popupTower");
        popupTower = popup.GetComponent<Popup>();
        popupSelectMap = popup.GetComponent<PopupSelectMap>();
        towerName.text = gameObject.name;
    }
    void Update()
    {
        if (isDoubleClicked)
        {
            OpenPopup();
            isDoubleClicked = false;
        }
    }
    private void OpenPopup()
    {
        if (thisFloorList != null)
        {
            popupSelectMap.Setup(thisFloorList, gameObject.name, dungeonType);
            popupTower.TogglePopup();
        }
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
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
}
