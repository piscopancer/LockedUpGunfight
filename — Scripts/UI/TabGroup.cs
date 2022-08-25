using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TriInspector;

[System.Serializable]
public class TabGroup
{
    [SerializeField] List<TabGroupButton> listButtons;
    [field: SerializeField, ReadOnly] public TabGroupButton ButtonSelected { get; private set; } = null;
    [SerializeField, Required, InlineEditor] ColorCustom colorSelectedFront, colorSelectedBack, 
        colorNotSelectedFront, colorNotSelectedBack;

    public void DisplayButtonSelected(TabGroupButton buttonClicked)
    {
        foreach (var button in listButtons)
        {
            if (button == buttonClicked)
            {
                button.SetColor(colorSelectedBack, colorSelectedFront);
                ButtonSelected = buttonClicked;
            }
            if (button != buttonClicked)
            {
                button.SetColor(colorNotSelectedBack, colorNotSelectedFront);
            }
        }
    }
}
