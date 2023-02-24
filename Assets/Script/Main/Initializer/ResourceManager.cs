using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResourceManager : MonoBehaviour
{
    Data data;
    [SerializeField] TextMeshProUGUI goldText;
    void Start()
    {
        data = DataManager.Data;
        goldText.text = "" + data.gold;
    }
}
