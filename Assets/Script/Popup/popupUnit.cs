using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class popupUnit : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI charName;
    [SerializeField] TextMeshProUGUI hp;
    [SerializeField] TextMeshProUGUI attack;
    [SerializeField] TextMeshProUGUI defence;
    [SerializeField] TextMeshProUGUI criRate;
    [SerializeField] TextMeshProUGUI criDamage;
    [SerializeField] TextMeshProUGUI explain;
    [SerializeField] Image portrait;
    UnitState unit;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        if (unit != null) Setup(unit);
    }
    public void Setup(UnitState unit)
    {
        this.unit = unit;
        Dictionary<status, double> unitStatus = unit.CurrentStatus;
        portrait.sprite = unit.ThisCharacter.portrait;
        explain.text = unit.ThisCharacter.explain;
        charName.text = unit.ThisCharacter.unitName;
        hp.text = "" + unit.ThisCharacter.hp;
        attack.text = "" + unitStatus[status.attackDamage];
        criRate.text = "" + unitStatus[status.criticalRate];
        criDamage.text = "" + unitStatus[status.criticalDamage];
        defence.text = "" + unitStatus[status.defence];
    }
}
