using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    JsonManager playerData = new JsonManager();
    static Data data;
    public static Data Data { get => data; }
    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        data = new Data(false);
        //Save();
        data = playerData.LoadJsonFile(playerData.FileName);//데이터 들고오기
    }
    public static void SetEquipmentData(equipment target, int value)
    {
        data.hasEquipment[target].currentIndex = value;
    }
    public void AddGold(int value)
    {
        data.gold += value;
    }
    public void AddPaint(int value)
    {
        data.paint += value;
    }
    public void Save()
    {
        playerData.SaveJsonFile(playerData.FileName, data);
    }
}
