using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TriInspector;

[RequireComponent(typeof(Image))]
public class ImageExtension : MonoBehaviour
{
    [SerializeField] bool ifBlink = false;
    [SerializeField, Min(0), ShowIf(nameof(ifBlink))] float timeBlinkOneWay = 0.5f;
    [SerializeField, Range(0, 1), ShowIf(nameof(ifBlink))] float blinkMin = 0, blinkMax = 1;
    Tween tweenBlink;
    [SerializeField] bool ifSpin = false;
    [SerializeField, ShowIf(nameof(ifSpin))] int degreesPerSecond;
    Tween tweenSpin;

    void Awake()
    {
        var image = GetComponent<Image>();
        if (ifBlink)
        {
            tweenBlink = image.DOFade(blinkMax, timeBlinkOneWay).From(blinkMin).SetLoops(-1, LoopType.Yoyo);
        }
        if (ifSpin)
        {
            tweenSpin = image.rectTransform.DOBlendableLocalRotateBy(Vector3.forward * degreesPerSecond, 1)
                .SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
        }
    }

    void OnDestroy()
    {
        tweenBlink.Kill();
        tweenSpin.Kill();
    }
}
