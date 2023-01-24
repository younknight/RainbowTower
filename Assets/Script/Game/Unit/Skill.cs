using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] int skillGauge;
    [SerializeField] float skillDamage;
    public int mp = 0;

    public int SkillGauge { get => skillGauge; set => skillGauge = value; }
    public int Mp { get => mp; set => mp = value; }

    void Awake()
    {
       StartCoroutine(UseSkill());
    }
    IEnumerator UseSkill()
    {
        while (true)
        {
            if (mp >= SkillGauge - 1)//스킬 사용
            {
                Debug.Log("에쿠수카리바");
                EnemyManager.EnemyList[0].PlayerDamaged(skillDamage);
                mp = 0;
            }
            yield return new WaitForSeconds(1f);
            if(mp < skillGauge) mp++;
        }
    }
}
