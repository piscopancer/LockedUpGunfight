using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TriInspector;
using DG.Tweening;

[RequireComponent(typeof(Button))]
public class TabGroupButton : MonoBehaviour
{
    const float TIME_ANIM = 0.15f;
    string errorLog = "Some rects of TabGroupButton not assigned";
    [SerializeField, Required] List<RectTransform> listRectToColorBack, listRectToColorFront;

    public void SetColor(ColorCustom colorBack, ColorCustom colorFront)
    {
        if (listRectToColorBack.Count > 0)
        {
            foreach (var rect in listRectToColorBack)
            {
                if (rect.TryGetComponent(out TextMeshProUGUI text))
                {
                    text.DOColor(colorBack.Color, TIME_ANIM);
                }
                if (rect.TryGetComponent(out Image image))
                {
                    image.DOColor(colorBack.Color, TIME_ANIM);
                }
            }
        }
        else
        {
            Debug.Log(errorLog);
        }
        if (listRectToColorFront.Count > 0)
        {
            foreach (var rect in listRectToColorFront)
            {
                if (rect.TryGetComponent(out TextMeshProUGUI text))
                {
                    text.DOColor(colorFront.Color, TIME_ANIM);
                }
                if (rect.TryGetComponent(out Image image))
                {
                    image.DOColor(colorFront.Color, TIME_ANIM);
                }
            }
        }
        else
        {
            Debug.Log(errorLog);
        }
    }
}
