using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragedItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    Transform canvas;
    Transform previousParent;
    RectTransform rect;
    CanvasGroup canvasGroup;
    //Dragleitem
    public Transform PreviousParent { get => previousParent; }
    public RectTransform Rect { get => rect; }

    void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        previousParent = transform.parent;//slot들
        transform.SetParent(canvas);
        transform.SetAsLastSibling();
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        //Debug.Log(previousParent.name);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent == canvas)//벗어났을경우 되돌리는 녀석
        {
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
        }
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }
}
