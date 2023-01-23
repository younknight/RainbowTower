using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillGaugeControl : MonoBehaviour
{
    [SerializeField] GameObject GaugePrefab;
    List<GameObject> Gauge = new List<GameObject>();
    Skill skill;
    void Start()
    {
        skill = GameObject.FindWithTag("Player").GetComponent<Skill>();
        for (int i = 0; i < skill.SkillGauge; i++)
        {
            GameObject newGauge = Instantiate(GaugePrefab, Vector3.zero, Quaternion.identity, this.transform);
            newGauge.SetActive(false);
            Gauge.Add(newGauge);
        }
    }
    private void Update()
    {
        if (skill.Mp == 0)
        {
            foreach (GameObject gauge in Gauge)
            {
                gauge.SetActive(false);
            }
        }
        Gauge[skill.Mp].SetActive(true);
    }
}
