using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewColor", menuName = "NewColor/Color")]

public class ColorStatusPrefap : ScriptableObject
{
    public Sprite sprite;
    public equipment spriteTarget;
    public int index;
    //스테이터스
    public int hp;
    public int attackDamage;
    public int criticalRate;
    public int criticalDamage;
}
