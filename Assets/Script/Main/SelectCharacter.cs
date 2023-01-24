using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SelectCharacter : MonoBehaviour
{
    [SerializeField] GameObject character;
    [SerializeField] Sprite portrait;
    UnitPrefap information;
    public UnitPrefap Information { get => information; set => information = value; }
    public GameObject Character { get => character; set => character = value; }
    public Sprite Portrait { get => portrait; set => portrait = value; }

    private void Start()
    {
        Information = Character.GetComponent<UnitState>().ThisCharacter;
        Image image = transform.GetChild(0).GetComponent<Image>();
        image.sprite = Portrait;
        if (PlayerDatabase.Character == null) PlayerDatabase.SetCharacter(Character);
    }
}
