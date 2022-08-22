using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class PanelBase : MonoBehaviour
{
    const float TIME_ANIM_OPEN = 0.1f;

    public static Action<PanelBase> OnOpened, OnClosed;

    protected List<Tween> ListTweens;

    protected virtual void Awake()
    {
        OnOpened?.Invoke(this);
        var tweenOpen = GetComponent<CanvasGroup>().DOFade(1, TIME_ANIM_OPEN);
        ListTweens.Add(tweenOpen);
    }

    public virtual void Close()
    {
        OnClosed?.Invoke(this);
        foreach (var tween in ListTweens)
        {
            tween?.Kill();
        }
        Destroy(gameObject);
    }
}
