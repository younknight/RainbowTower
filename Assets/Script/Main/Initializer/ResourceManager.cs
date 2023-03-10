using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResourceManager : MonoBehaviour
{
    DataPlayer data;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI paintText;
    void Start()
    {
        data = DataManager.DataPlayer;
    }
    private void Update()
    {
        goldText.text = "" + data.gold;
        paintText.text = "" + data.paint;
    }
}
