using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class MapSelector : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI towerName;
    [SerializeField] List<FloorPrefap> thisFloorList;
    [SerializeField] DungeonType dungeonType;
    Popup popupTower;
    public PopupSelectMap popupSelectMap;//

    static FloorPrefap floorPrefap;
    public static FloorPrefap FloorPrefap { get => floorPrefap; set => floorPrefap = value; }

    private void Awake()
    {
        var popup = GameObject.Find("popupTower");
        popupTower = popup.GetComponent<Popup>();
        popupSelectMap = popup.GetComponent<PopupSelectMap>();
        towerName.text = gameObject.name;
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
        OpenPopup();
    }
}
