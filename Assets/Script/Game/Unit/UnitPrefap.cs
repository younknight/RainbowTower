using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewUnit", menuName = "NewUnit/Unit")]

public class UnitPrefap : ScriptableObject
{
    public List<Item> startItem;
    public Sprite portrait;

    public double hp;
    public double attackDamage;
    public double criticalRate;
    public double criticalDamage;
    public double defence;
    public double magicDamage;
    public skillType skillType;
    public string explain;
}
