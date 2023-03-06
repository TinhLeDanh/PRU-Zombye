using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableComponent : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler,
    IEndDragHandler
{
    public event Action<PointerEventData> OnBeginDragHandler;
    public event Action<PointerEventData> OnDragHandler;
    public event Action OnEndDragHandler;

    public bool FollowCursor { get; set; }
    public Vector3 StartPosition;
    public bool CanDrag { get; set; } = true;

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!CanDrag){
            return;
        }
        OnDragHandler?.Invoke(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}