using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class JsonManager
{
    string fileNamePlayer = "PlayerData";
    string fileNameSetting = "SettingData";
    public string FileNamePlayer { get => fileNamePlayer; }
    public string FileNameSetting { get => fileNameSetting; }

    public void SavePlayerData(string fileName, DataPlayer data)
    {
        string jsonData = ObjectToJson(data);
        File.WriteAllText(Application.dataPath + "/" + fileName + ".json", jsonData);
    }
    public void SaveSettingData(string fileName, DataSetting data)
    {
        string jsonData = ObjectToJson(data);
        File.WriteAllText(Application.dataPath + "/" + fileName + ".json", jsonData);
    }
    public DataPlayer LoadPlayerData(string fileName)
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/" + fileName + ".json");
        DataPlayer obj = JsonToOject<DataPlayer>(jsonData);
        return obj;
    }
    public DataSetting LoadSettingData(string fileName)
    {

        string jsonData = File.ReadAllText(Application.dataPath + "/" + fileName + ".json");
        DataSetting obj = JsonToOject<DataSetting>(jsonData);
        return obj;
    }
    string ObjectToJson(object obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
    T JsonToOject<T>(string jsonData)
    {
        return JsonConvert.DeserializeObject<T>(jsonData);
    }
}
