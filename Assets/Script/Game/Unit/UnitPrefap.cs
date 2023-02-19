using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewUnit", menuName = "NewUnit/Unit")]

public class UnitPrefap : ScriptableObject
{
    public Sprite portrait;
    public float hp;
    public float attackDamage;
    public float criticalRate;
    public float criticalDamage;
    public float defence;
    public string explain;
    public Item[] dropItems;
}
