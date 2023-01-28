using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class JsonManager 
{
    string fileName = "PlayerData";
    public string FileName { get => fileName; }

    public void SaveJsonFile(string fileName, Data data)
    {
        string jsonData = ObjectToJson(data);
        File.WriteAllText(Application.dataPath + "/" + fileName + ".json", jsonData);
    }
    public Data LoadJsonFile(string fileName)
    {
        string jsonData = File.ReadAllText(Application.dataPath + "/" + fileName + ".json");
        Data obj = JsonToOject<Data>(jsonData);
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
