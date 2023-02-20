using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ButtonManager : MonoBehaviour
{
    [SerializeField] Image portrait;
    [SerializeField] TextMeshProUGUI numText;
    [SerializeField] equipment equipmentType;
    [SerializeField] colorType color;
    private static GameObject selectedBtn;
    Item item;
    public equipment EquipmentType { get => equipmentType; }
    public static GameObject SelectedBtn { get => selectedBtn;  }
    public Item Item { get => item; set => item = value; }
    public colorType Color { get => color; }

    public void ChangePortrait(Sprite sprite)
    {
        portrait.sprite = sprite;
    }
    public void SelectThisBtn()
    {
        selectedBtn = gameObject;
    }
}
