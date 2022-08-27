using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;
using UnityEngine.UI;

public class PanelMenu : PanelBase, ITemporarySubscriber
{
    [SerializeField, Required] Button buttonSettings, buttonQuit;
    [SerializeField, Required] Button buttonLevels, buttonInfinite;

    public static Action OnSettingsClicked, OnQuitClicked, OnLevelsClicked, OnInfiniteClicked;

    protected override void Awake()
    {
        base.Awake();

        buttonSettings.onClick.AddListener(delegate
        {
            OnSettingsClicked?.Invoke();
        });
        buttonQuit.onClick.AddListener(delegate 
        {
            OnQuitClicked?.Invoke();
        }); 
        buttonLevels.onClick.AddListener(delegate
        {
            OnLevelsClicked?.Invoke();
        });
        buttonInfinite.onClick.AddListener(delegate 
        {
            OnInfiniteClicked?.Invoke();
        });

        Subscribe();
    }

    void OnDestroy()
    {
        Unsubscribe();    
    }

    public void Subscribe()
    {
        OnOpened += ReactionOnOpened;
    }

    public void Unsubscribe()
    {
        OnOpened -= ReactionOnOpened;
    }

    void ReactionOnOpened(PanelBase panelOpened)
    {
        if (panelOpened is PanelSettings)
        {
            Close();
        }
    }
}
