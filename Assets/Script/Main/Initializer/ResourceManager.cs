using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResourceManager : MonoBehaviour
{
    Data data;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI paintText;
    void Start()
    {
        data = DataManager.Data;
    }
    private void Update()
    {
        goldText.text = "" + data.gold;
        paintText.text = "" + data.paint;
    }
}
