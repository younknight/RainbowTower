using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    UnitState playerStatus;
    [SerializeField] List<equipment> keys = new List<equipment>();
    [SerializeField] List<SpriteRenderer> values = new List<SpriteRenderer>();
    Dictionary<equipment, SpriteRenderer> playerEquipment = new Dictionary<equipment, SpriteRenderer>();
    private void Start()
    {
        playerStatus = gameObject.GetComponent<UnitState>();
        playerStatus.InitStatus(PlayerManager.playerStatus);
        SetEquipment();
    }
    void SetEquipment()
    {
        if (keys.Count != values.Count) throw new System.Exception("keys.Count != values.Count");
        for (int i = 0; i < keys.Count; i++)
        {
            playerEquipment.Add(keys[i], values[i]);
        }
        foreach (KeyValuePair<equipment, Sprite> entry in PlayerManager.playerSprite)
        {
            if (entry.Value != null) playerEquipment[entry.Key].sprite = entry.Value;
        }
    }
}
