using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    JsonManager jsonManager = new JsonManager();
    static DataPlayer dataPlayer;
    static DataSetting dataSetting;
    public static DataPlayer DataPlayer { get => dataPlayer; }
    public static DataSetting DataSetting { get => dataSetting; }

    void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
        dataPlayer = new DataPlayer(false);
        dataSetting = new DataSetting();
        //Save();
        dataPlayer = jsonManager.LoadPlayerData(jsonManager.FileNamePlayer);//데이터 들고오기
        dataSetting = jsonManager.LoadSettingData(jsonManager.FileNameSetting);//데이터 들고오기
    }
    public void ResetData(DataPlayer _dataPlayer, DataSetting _dataSetting)
    {
        dataPlayer = _dataPlayer;
        dataSetting= _dataSetting;
    }
    public void Save()
    {
        jsonManager.SavePlayerData(jsonManager.FileNamePlayer, dataPlayer);
        jsonManager.SaveSettingData(jsonManager.FileNameSetting, dataSetting);
    }
}
