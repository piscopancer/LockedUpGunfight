using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField, Required] RectTransform holderPanels;
    [SerializeField, Required, AssetsOnly] PanelBase panelMenu, panelSettings;

    void Awake()
    {
        PanelBase.OnOpened += delegate (PanelBase panel)
        {
            
        };
        PanelBase.OnClosed += delegate (PanelBase panel)
        {
            if (panel is PanelSettings)
            {
                OpenPanel(panelMenu);
            };
        };
        PanelMenu.OnSettingsClicked += delegate
        {
            OpenPanel(panelSettings);
        };
    }

    void OpenPanel(PanelBase panel)
    {
        var newPanel = Instantiate(panel, holderPanels);
    }
}
