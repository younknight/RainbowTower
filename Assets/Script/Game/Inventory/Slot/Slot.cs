using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public enum SlotType { inventory, equipment }
public class Slot : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    public Image itemImage;
    public int index;//
    [SerializeField] SlotType slotType;
    Popup popup;
    PopupItem popupItem;

    static Dictionary<colorType, Graph> graph = new Dictionary<colorType, Graph>()
    {
        {colorType.red, new Graph(16)},
        {colorType.orange, new Graph(16)},
        {colorType.yellow, new Graph(16)},
        {colorType.green, new Graph(16)},
        {colorType.blue, new Graph(16)},
        {colorType.purple, new Graph(16)}
    };
    public int Index { get => index; set => index = value; }
    public SlotType SlotType { get => slotType; }
    public static Dictionary<colorType, Graph> Graph { get => graph; set => graph = value; }

    void Awake()
    {
        GameObject PopupObj = GameObject.Find("PopupItem");
        popup = PopupObj.GetComponent<Popup>();
        popupItem = PopupObj.GetComponent<PopupItem>();
        itemImage = transform.GetChild(0).GetComponent<Image>();
        ClearSlot();
    }
    public int likedNum()
    {
        Debug.Log("탐색 결과" + graph[item.colorType].BFS(index));
        return graph[item.colorType].BFS(index);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (item != null)
            {
                popup.TogglePopup();
                popupItem.Setup(this);
            }
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Inventory.Instance.GetSp(10);
            item = null;
            itemImage.sprite = null;
            ClearSlot();
        }
    }
    public void AddItem(Item _item)
    {
        item = _item;
        itemImage.sprite = item.sprite;
        SetColor(1);
    }
    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null;
        SetColor(0);
    }
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }
}
