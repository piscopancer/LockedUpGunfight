using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TriInspector;

[RequireComponent(typeof(Image))]
public class ImageExtension : MonoBehaviour
{
    [SerializeField] bool ifBlink = true;
    [SerializeField, Min(0), EnableIf(nameof(ifBlink))] float timeBlinkOneWay = 0.5f;
    [SerializeField, Range(0, 1), EnableIf(nameof(ifBlink))] float blinkMin = 0, blinkMax = 1;
    Tween tweenBlink;

    void Awake()
    {
        var image = GetComponent<Image>();
        if (ifBlink)
        {
            tweenBlink = image.DOFade(blinkMax, timeBlinkOneWay).From(blinkMin).SetLoops(-1, LoopType.Yoyo);
        }
    }

    void OnDestroy()
    {
        tweenBlink?.Kill();
    }
}
