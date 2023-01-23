using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTitle : MonoBehaviour
{
    public static PlayerTitle instance;
    [SerializeField] Image playerImage;
    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        instance = this;
    }
    public void SetImage(Sprite sprite)
    {
        playerImage.sprite = sprite;
    }
}
