using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextWithTranslation : MonoBehaviour
{
    [SerializeField, Required, InlineEditor] Translation translation;

    void Awake()
    {
        Language.OnLanguageChanged += SetText;
        if (translation != null)
        {
            SetText(Language.LanguageCurrent);
        }
        if (translation == null)
        {
            Debug.LogWarning(gameObject + "is missing Translation");
        }
    }

    void OnDestroy()
    {
        Language.OnLanguageChanged -= SetText;
    }

    void SetText(Languages lang)
    {
        GetComponent<TextMeshProUGUI>().text = translation.Text;
    }

    public void SetText(Translation translation)
    {
        this.translation = translation;
        SetText(Language.LanguageCurrent);
    }

    [Button("Update Text")]
    void UpdateTextEditor()
    {
        if (translation == null)
        {
            GetComponent<TextMeshProUGUI>().text = "---";
            return;
        }
        GetComponent<TextMeshProUGUI>().text = translation.Text;
    }
}
