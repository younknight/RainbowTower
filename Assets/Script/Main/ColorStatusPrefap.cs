using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewColor", menuName = "NewColor/Color")]

public class ColorStatusPrefap : ScriptableObject
{
    public Sprite sprite;
    public equipment spriteTarget;
    public int index;
    //�������ͽ�
    public int hp;
    public int attackDamage;
    public int criticalRate;
    public int criticalDamage;
}
