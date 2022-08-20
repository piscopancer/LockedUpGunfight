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
        SetText(Language.LanguageCurrent);
    }

    void OnDestroy()
    {
        Language.OnLanguageChanged -= SetText;
    }

    void SetText(Languages lang)
    {
        GetComponent<TextMeshProUGUI>().text = translation.Text;
    }

    public void SetTranslation(Translation translation)
    {
        this.translation = translation;
        SetText(Language.LanguageCurrent);
    }

    [Button("Update Text")]
    void UpdateTextEditor()
    {
        GetComponent<TextMeshProUGUI>().text = translation.Text;
    }
}
