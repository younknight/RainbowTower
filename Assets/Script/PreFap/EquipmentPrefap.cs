using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewEquipment", menuName = "NewEquipment/Equipment")]
//장비창
public class EquipmentPrefap : ScriptableObject
{
    public Sprite sprite;
    public equipment spriteTarget;
    public int index;
    public string equipmentName;
    //스테이터스
    public int hp;
    public int defence;
    public int attackDamage;
    public int criticalRate;
    public int criticalDamage;
    //상점
    public int priceGold;
    public int pricePaint;
    public string explain;
}
