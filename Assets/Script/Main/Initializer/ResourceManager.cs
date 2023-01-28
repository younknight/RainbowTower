using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResourceManager : MonoBehaviour
{
    Data data;
    [SerializeField] colorType[] key;
    [SerializeField] TextMeshProUGUI[] value;
    Dictionary<colorType, TextMeshProUGUI> colorTexts = new Dictionary<colorType, TextMeshProUGUI>();
    void Start()
    {
        data = DataManager.Data;
        for(int i=0;i< key.Length; i++)
        {
            colorTexts.Add(key[i], value[i]);
        }
        foreach (KeyValuePair<colorType, int> entry in data.hasColor)
        {
            colorTexts[entry.Key].text = "" + entry.Value;
        }
    }
}
