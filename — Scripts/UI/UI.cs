using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField, Required] RectTransform holderPanels;
    [SerializeField, Required, AssetsOnly] PanelBase panelMenu, panelDockBottom, panelSettings,
        panelSelectLevel;

    void Awake()
    {
        OpenPanel(panelMenu);
        OpenPanel(panelDockBottom);

        PanelBase.OnClosed += delegate (PanelBase panelClosed)
        {
            if (panelClosed is PanelSettings
            || panelClosed is PanelSelectLevel)
            {
                OpenPanel(panelMenu);
                OpenPanel(panelDockBottom);
            };
        };
        PanelMenu.OnSettingsClicked += delegate
        {
            OpenPanel(panelSettings);
        };
        PanelMenu.OnLevelsClicked += delegate
        {
            OpenPanel(panelSelectLevel);
        };
    }

    void OpenPanel(PanelBase panel)
    {
        var newPanel = Instantiate(panel, holderPanels);
    }
}
