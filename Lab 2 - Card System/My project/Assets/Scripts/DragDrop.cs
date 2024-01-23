using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {
    private RectTransform rectTransform;

    void Start() {
        rectTransform = this.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData edata) {
        //wah wah
    }

    public void OnBeginDrag(PointerEventData edata) {
        //wah wah
    }

    public void OnDrag(PointerEventData edata) {
        this.rectTransform.anchoredPosition += edata.delta;
    }

    public void OnEndDrag(PointerEventData edata) {
        //SendMessageOptions.DontRequireReciever throws an error for some unknown reason
        this.SendMessage("OnPlay");
    }
}
