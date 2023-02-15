using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HpControl : MonoBehaviour
{
    [SerializeField] GameObject thisUnit;
    [SerializeField] TextMeshProUGUI text;
    UnitState unitState;
    public float maxHp;
    public float hp;
    Slider hpbar;
    bool isSetup = false;
    private void Start()
    {
        if(thisUnit != null)
        {
            Setup(thisUnit.GetComponent<UnitState>());
        }
    }
    private void Update()
    {
        if (isSetup && unitState !=null)
        {
            hpbar.value = (float)unitState.CurrentStatus[status.hp] / maxHp;
            hp = (float)unitState.CurrentStatus[status.hp];
            text.text = "" + unitState.CurrentStatus[status.hp] + "/" + maxHp;
        }
    }
    public void Setup(UnitState unitState)
    {
        hpbar = gameObject.GetComponent<Slider>();
        maxHp = (float)unitState.CurrentStatus[status.hp];
        this.unitState = unitState;
        isSetup = true;
    }
}
