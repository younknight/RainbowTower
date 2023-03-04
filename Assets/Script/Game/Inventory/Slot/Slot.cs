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
    [SerializeField] Image frameColor;
    [SerializeField] int linkedItemNum = 1;
    public int index;//
    [SerializeField] SlotType slotType;
    Popup popup;
    PopupItem popupItem;

    static Dictionary<colorType, Graph> graph = new Dictionary<colorType, Graph>();
    public int Index { get => index; set => index = value; }
    public SlotType SlotType { get => slotType; }
    public static Dictionary<colorType, Graph> Graph { get => graph; set => graph = value; }
    public int LinkedItemNum { get => linkedItemNum; set => linkedItemNum = value; }
    void Awake()
    {
        ResetGraph();
        GameObject PopupObj = GameObject.Find("PopupItem");
        popup = PopupObj.GetComponent<Popup>();
        popupItem = PopupObj.GetComponent<PopupItem>();
        itemImage = transform.GetChild(0).GetComponent<Image>();
        ClearSlot();
    }
    void ResetGraph()
    {
        graph.Remove(colorType.red);
        graph.Remove(colorType.orange);
        graph.Remove(colorType.yellow);
        graph.Remove(colorType.green);
        graph.Remove(colorType.blue);
        graph.Remove(colorType.purple);
        //그래프 초기화
        graph.Add(colorType.red, new Graph(16));
        graph.Add(colorType.orange, new Graph(16));
        graph.Add(colorType.yellow, new Graph(16));
        graph.Add(colorType.green, new Graph(16));
        graph.Add(colorType.blue, new Graph(16));
        graph.Add(colorType.purple, new Graph(16));
        //
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
        if (eventData.button == PointerEventData.InputButton.Right && item != null)
        {
            DropItem.Instance.DropSlotInItem(this);
        }
    }
    public void test()
    {
        graph[colorType.red].test();
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
    public void SetFrameColor(colorType colorType)
    {
        Color color = new Color();
        switch (colorType)
        {
            case colorType.red:
                color = new Color(1f, 0.79f, 0.77f);
                break;
            case colorType.orange:
                color = new Color(0.99f, 0.9f, 0.77f);
                break;
            case colorType.yellow:
                color = new Color(1f, 0.99f, 0.74f);
                break;
            case colorType.green:
                color = new Color(0.81f, 1f, 0.73f);
                break;
            case colorType.blue:
                color = new Color(0.81f, 0.99f, 1f);
                break;
            case colorType.purple:
                color = new Color(0.98f, 0.85f, 1f);
                break;
            case colorType.gray:
                color = Color.white;
                break;
        }
        frameColor.color = color;
    }
}
