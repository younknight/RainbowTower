using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public enum TownType
{
    Home,
    Shop
}

public class PopupTown : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI towerName;
    [SerializeField] TextMeshProUGUI explain;
    TownType TownType;
    void Start()
    {
        gameObject.SetActive(false);
    }
    public void Setup(TownType townType)
    {
        TownType = townType;
        switch (townType)
        {
            case TownType.Home:
                towerName.text = "아늑한 우리 집";
                explain.text = "이러쿵 저러쿵\n뭐라고 해도\n집이 최고지\n이불밖은\n너무 위험해!";
                break;
            case TownType.Shop:
                towerName.text = "아저씨의 상점";
                explain.text = "아저씨가 운영하는\n작은 상점\n충동구매 금지";
                break;
        }
    }
    public void MoveScean()
    {
        switch (TownType)
        {
            case TownType.Home:
                SceneManager.LoadScene("Main");
                break;
            case TownType.Shop:
                SceneManager.LoadScene("Shop");
                break;
        }
    }
}