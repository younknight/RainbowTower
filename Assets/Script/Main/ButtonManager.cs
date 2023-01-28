using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] Image portrait;
    [SerializeField] equipment equipmentType;

    public equipment EquipmentType { get => equipmentType; }

    public void ChangePortrait(Sprite sprite)
    {
        portrait.sprite = sprite;
    }
}
