using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewUnit", menuName = "NewUnit/Unit")]

public class UnitPrefap : ScriptableObject
{
    public Sprite portrait;
    public double hp;
    public double attackDamage;
    public double criticalRate;
    public double criticalDamage;
    public double defence;
    public string explain;
    public Item[] dropItems;
}
