using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewPlayer", menuName = "NewPlayer/Caracter")]

public class PlayerPrefab : ScriptableObject
{
    public enum SkillType
    {
        Attack,
        Heal
    }
    public Sprite PlayerImage;
    public List<Item> startItem; 

    public float hp;
    public float attackDamage;
    public float critcalRate;
    public float critcalDamage;
    public float defence;
    public float magicDamage;
    public SkillType skillType;
}
