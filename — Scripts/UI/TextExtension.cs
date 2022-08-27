using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TriInspector;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextExtension : MonoBehaviour
{
    [SerializeField] bool ifBlink = false;
    [SerializeField, Min(0), ShowIf(nameof(ifBlink))] float timeBlinkOneWay = 0.5f;
    [SerializeField, Range(0, 1), ShowIf(nameof(ifBlink))] float blinkMin = 0, blinkMax = 1;
    Tween tweenBlink;

    void Awake()
    {
        var text = GetComponent<TextMeshProUGUI>();
        if (ifBlink)
        {
            tweenBlink = text.DOFade(blinkMax, timeBlinkOneWay).From(blinkMin).SetLoops(-1, LoopType.Yoyo);
        }
    }

    void OnDestroy()
    {
        tweenBlink.Kill();
    }
}
