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
            OnSettingsClicked?.Invoke();
            Close();
        });
        buttonQuit.onClick.AddListener(delegate 
        {
            OnQuitClicked?.Invoke();
        });    
    }
}
