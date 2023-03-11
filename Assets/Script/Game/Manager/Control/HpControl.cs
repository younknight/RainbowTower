using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HpControl : MonoBehaviour
{
    [SerializeField] GameObject thisUnit;
    [SerializeField] bool isPlayer;
    [SerializeField] TextMeshProUGUI text;
    UnitState unitState;
    public float maxHp;
    public float hp;
    Slider hpbar;
    Image fill;
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
            if((float)unitState.CurrentStatus[status.hp] / maxHp <= 1)
            {
                hpbar.value = (float)unitState.CurrentStatus[status.hp] / maxHp;
            }
            else
            {
                hpbar.value = 1f;
            }
            if(isPlayer)SetColor(hpbar.value);
            hp = (float)unitState.CurrentStatus[status.hp];
            text.text = "" + (int)unitState.CurrentStatus[status.hp] + "/" + maxHp;
        }
    }
    void SetColor(float value)
    {
        Color color = Color.white;
        if(value > 0.5)
        {
            color = Color.green;
        }
        else if(value > 0.3)
        {
            color = Color.yellow;
        }
        else
        {
            color = Color.red;
        }
        fill.color = color;
    }
    public void Setup(UnitState unitState)
    {
        hpbar = gameObject.GetComponent<Slider>();
        fill = hpbar.transform.Find("FillArea").transform.GetChild(0).GetComponent<Image>();
        maxHp = (float)unitState.CurrentStatus[status.hp];
        this.unitState = unitState;
        isSetup = true;
    }
}
