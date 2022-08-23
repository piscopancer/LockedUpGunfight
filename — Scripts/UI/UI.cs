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
        OpenPanel(panelMenu);

        PanelBase.OnOpened += delegate (PanelBase thisPanel)
        {
            
        };
        PanelBase.OnClosed += delegate (PanelBase thisPanel)
        {
            if (thisPanel is PanelSettings)
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
