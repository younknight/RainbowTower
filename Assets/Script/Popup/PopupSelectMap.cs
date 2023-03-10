using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopupSelectMap : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI towerName;
    [SerializeField] TextMeshProUGUI explain;
    [SerializeField] Transform floorFarent;
    [SerializeField] GameObject gameStart;
    [SerializeField] GameObject locked;
    [SerializeField] List<FloorPrefap> thisFloorPrefap;//
    public int height;
    Floor[] floors;
    // Start is called before the first frame update
    void Start()
    {
        floors = floorFarent.transform.GetComponentsInChildren<Floor>();
        gameObject.SetActive(false);
    }
    public void Setup(List<FloorPrefap> floorPrefap, string name, DungeonType dungeonType)
    {
        thisFloorPrefap = floorPrefap;
        height = thisFloorPrefap.Count;
        for (int i = 0; i < floors.Length; i++)
        {
            floors[i].gameObject.SetActive(false);
            if (i < height)
            {
                floors[i].gameObject.SetActive(true);
                floors[i].Height = i;
                floors[i].Setup(i, floorPrefap[i], dungeonType);
                if(DataManager.DataPlayer.clearFloor[thisFloorPrefap[0].dungeonType] < i)//잠김
                {
                    floors[i].SetMapPortrait(true);
                }
                else//안잠김
                {
                    floors[i].SetMapPortrait(false);
                }
            }
        }
        gameStart.SetActive(false);
        locked.SetActive(false);
        towerName.text = name;
        explain.text = "";
    }
    public void LockedFloor()
    {
        explain.text = "잠겨있다";
    }
}
