using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Floor : MonoBehaviour
{
    [SerializeField] Image mapPortrait;
    [SerializeField] Sprite locked;
    [SerializeField] TextMeshProUGUI floor;
    [SerializeField] FloorPrefap floorPrefap;
    [SerializeField] TextMeshProUGUI explain;
    int height;
    GameObject goGameBtn;
    GameObject lockedBtn;
    DungeonType dungeonType;
    public int Height { get => height; set => height = value; }

    private void Awake()
    {
        var setting = GameObject.Find("setting");
        explain = setting.transform.Find("explain").GetChild(0).GetComponent<TextMeshProUGUI>();
        goGameBtn = setting.transform.Find("GoGame").gameObject;
        lockedBtn = setting.transform.Find("Locked").gameObject;
    }
    public void Setup(int height, FloorPrefap floorPrefap, DungeonType dungeonType)
    {
        floor.text = (height + 1) + "F";
        this.floorPrefap = floorPrefap;
        this.dungeonType = dungeonType;
    }
    public void SetStage()
    {
        goGameBtn.SetActive(false);
        lockedBtn.SetActive(false);
        //MapSelector.EnemyList.RemoveAll(x => true);
        MapSelector.FloorPrefap = floorPrefap;
        if (DataManager.DataPlayer.clearFloor[dungeonType] >= height)
        {
            explain.text = floorPrefap.explain;
            goGameBtn.SetActive(true);
        }
        else
        {
            explain.text = "잠겨있다";
            lockedBtn.SetActive(true);
        }
    }
    public void SetMapPortrait(bool isLocekd)
    {
        if (isLocekd)
        {
            mapPortrait.sprite = locked;
            return;
        }
        mapPortrait.sprite = floorPrefap.portrait;
    }
}
