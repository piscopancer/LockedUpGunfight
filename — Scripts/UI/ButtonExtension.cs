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
    const float SIZE_CLICKED = 0.9f;
    [SerializeField] bool ifOutline = false;
    [SerializeField, Required, OnValueChanged(nameof(ClickedImageTransparent)), ShowIf(nameof(ifOutline))] Image clickedImage;
    [SerializeField] bool ifChangeSize = false;
    Tween tweenTransparency, tweenChangeSize;

    void Awake()
    {
        if (ifOutline)
        {
            ClickedImageTransparent();
        }
    }

    void OnDestroy()
    {
        tweenTransparency.Kill();
        tweenChangeSize.Kill();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (ifOutline)
        {
            tweenTransparency = clickedImage.DOFade(1, TIME_ANIM).From(0);
        }
        if (ifChangeSize)
        {
            tweenChangeSize = GetComponent<RectTransform>().DOScale(SIZE_CLICKED, TIME_ANIM);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (ifOutline)
        {
            tweenTransparency = clickedImage.DOFade(0, TIME_ANIM).From(1);
        }
        if (ifChangeSize)
        {
            GetComponent<RectTransform>().DOScale(1, TIME_ANIM);
        }
    }

    void ClickedImageTransparent()
    {
        clickedImage.DOFade(0, 0.1f).From(0);
    }
}
