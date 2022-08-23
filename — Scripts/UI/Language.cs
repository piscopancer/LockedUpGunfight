using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Language : MonoBehaviour
{
    [SerializeField] Languages languageCurrent = Languages.English;
    public static Languages LanguageCurrent
    {
        get
        {
            return FindObjectOfType<Language>().languageCurrent;
        }
        set
        {
            var language = FindObjectOfType<Language>();
            language.languageCurrent = value;
            OnLanguageChanged?.Invoke(value);
        }
    }

    public static Action<Languages> OnLanguageChanged;

    void Awake()
    {
        SaveSystem.OnSaveLoaded += delegate (SaveSystem.SaveData save)
        {
            languageCurrent = save.LanguageCurrent;
        };
        PanelSettings.OnLanguageClicked += delegate (Languages newLang)
        {
            LanguageCurrent = newLang;
        };
    }
}

public enum Languages
{
    English,
    Russian
}
