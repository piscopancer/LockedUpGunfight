using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;

[CreateAssetMenu(menuName = "Data/Translation")]
public class Translation : ScriptableObject
{
    public string Text
    {
        get
        {
            switch (Language.LanguageCurrent)
            {
                case Languages.English:
                    return TextEnglish;
                case Languages.Russian:
                    return TextRussian;
                default:
                    return TextEnglish;
            }
        }
    }

    [Required, SerializeField, TextArea(1, 20)] string TextEnglish, TextRussian;
}
