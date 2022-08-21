using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TriInspector;
using DG.Tweening;

[RequireComponent(typeof(Button))]
public class ButtonExtension : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    const float TIME_ANIM = 0.15f; 
    [SerializeField, Required, OnValueChanged(nameof(ClickedImageTransparent))] Image clickedImage;
    Tween tweenTransparency;

    void Start()
    {
        ClickedImageTransparent();
    }

    void OnDestroy()
    {
        tweenTransparency?.Kill();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        tweenTransparency = clickedImage.DOFade(1, TIME_ANIM).From(0);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        tweenTransparency = clickedImage.DOFade(0, TIME_ANIM).From(1);
    }

    void ClickedImageTransparent()
    {
        clickedImage.DOFade(0, 0.1f).From(0);
    }
}
