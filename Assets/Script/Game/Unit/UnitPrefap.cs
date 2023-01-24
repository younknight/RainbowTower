using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewUnit", menuName = "NewUnit/Unit")]

public class UnitPrefap : ScriptableObject
{
    public enum SkillType
    {
        Attack,
        Heal
    }
    public List<Item> startItem;
    public Sprite portrait;

    public float hp;
    public float attackDamage;
    public float critcalRate;
    public float critcalDamage;
    public float defence;
    public float magicDamage;
    public SkillType skillType;
    public string explain;
}
