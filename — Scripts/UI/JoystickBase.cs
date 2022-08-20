using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using UnityEngine.EventSystems;
using System;

[DeclareBoxGroup("Size", Title = "Size")]
public class JoystickBase : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField, ReadOnly] Vector2 value;
    [SerializeField, ReadOnly] Vector2 bodyPos;
    [SerializeField, Required] RectTransform zone, body, dot;
    [Group("Size"), SerializeField] int bodySize = 300, dotSize = 80;

    public static Action<Vector2> OnJoystickDown, OnJoystickDragged, OnJoystickUp;

    void Awake()
    {
        body.gameObject.SetActive(false);
        dot.gameObject.SetActive(false);
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        bodyPos = pointerEventData.pressPosition;
        body.gameObject.SetActive(true);
        body.anchoredPosition = pointerEventData.pressPosition;
        dot.gameObject.SetActive(true);
        dot.anchoredPosition = Vector2.zero;
        value = Vector2.zero;
        OnJoystickDown.Invoke(Vector2.zero);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 offset = Vector2.ClampMagnitude(eventData.position - bodyPos, bodySize / 2);
        dot.anchoredPosition = offset;
        value = Vector2.ClampMagnitude(offset / (bodySize / 2), 1);
        OnJoystickDragged.Invoke(value);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        body.gameObject.SetActive(false);
        dot.gameObject.SetActive(false);
        value = Vector2.zero;
        OnJoystickUp.Invoke(Vector2.zero);
    }

    [Button("Update"), Group("Size")]
    void UpdateSize()
    {
        body.sizeDelta = new Vector2Int(bodySize, bodySize);
        dot.sizeDelta = new Vector2Int(dotSize, dotSize);
    }


}
