using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    JsonManager jsonManager = new JsonManager();
    static DataPlayer data;
    static DataSetting dataSetting;
    public static DataPlayer DataPlayer { get => data; }
    public static DataSetting DataSetting { get => dataSetting; }

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        data = new DataPlayer(true);
        dataSetting = new DataSetting();
        //Save();
        data = jsonManager.LoadPlayerData(jsonManager.FileNamePlayer);//데이터 들고오기
        dataSetting = jsonManager.LoadSettingData(jsonManager.FileNameSetting);//데이터 들고오기
    }
    public void Save()
    {
        jsonManager.SavePlayerData(jsonManager.FileNamePlayer, data);
        jsonManager.SaveSettingData(jsonManager.FileNameSetting, dataSetting);
    }
}
