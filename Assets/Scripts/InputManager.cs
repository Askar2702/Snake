using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IPointerDownHandler , IPointerUpHandler
{
    public static InputManager instance { get; private set; }
    public event Action<float> SetPoint;
    private Vector2 _swipe;
    private Vector2 _pointDown;

    private void Awake()
    {
        if (!instance) instance = this;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _pointDown = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _swipe = _pointDown - eventData.position;
        if(_swipe.magnitude > 2)
        {
            if( Mathf.Abs(_swipe.x) > Mathf.Abs(_swipe.y))
            {
                SetPoint?.Invoke(_swipe.x);
            }
        }
    }
}
