using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class PanelBase : MonoBehaviour
{
    const float TIME_ANIM_OPEN = 0.15f;

    public static Action<PanelBase> OnOpened, OnClosed;

    protected List<Tween> ListTweens = new List<Tween>();

    protected virtual void Awake()
    {
        OnOpened?.Invoke(this);
        var tweenOpen = GetComponent<CanvasGroup>().DOFade(1, TIME_ANIM_OPEN).From(0);
        ListTweens.Add(tweenOpen);
    }

    public virtual void Close()
    {
        OnClosed?.Invoke(this);
        if (ListTweens.Count > 0)
        {
            foreach (var tween in ListTweens)
            {
                tween.Kill();
            }
        }
        Destroy(gameObject);
    }
}
