using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;
using UnityEngine.UI;

public class PanelMenu : PanelBase
{
    [SerializeField, Required] Button buttonSettings, buttonQuit;

    public static Action OnSettingsClicked, OnQuitClicked;

    protected override void Awake()
    {
        base.Awake();

        buttonSettings.onClick.AddListener(delegate
        {
            Close();
            OnSettingsClicked?.Invoke();
        });
        buttonQuit.onClick.AddListener(delegate 
        {
            OnQuitClicked?.Invoke();
        });    
    }
}
