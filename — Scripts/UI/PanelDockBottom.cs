using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TriInspector;
using System;

public class PanelDockBottom : PanelBase
{
    [SerializeField, Required] ColorCustom colorBlue, colorWhite;
    [SerializeField] TabGroup tabGroupMainButtons;
    [SerializeField, Required] Button buttonGuns, buttonMenu, buttonCharacter;

    public static Action OnGunsClicked, OnMenuClicked, OnCharacterClicked;

    protected override void Awake()
    {
        base.Awake();

        buttonGuns.onClick.AddListener(delegate
        {
            OnGunsClicked?.Invoke();
            tabGroupMainButtons.DisplayButtonSelected(buttonGuns.GetComponent<TabGroupButton>());
        });
        buttonMenu.onClick.AddListener(delegate
        {
            OnMenuClicked?.Invoke();
            tabGroupMainButtons.DisplayButtonSelected(buttonMenu.GetComponent<TabGroupButton>());
        });
        buttonCharacter.onClick.AddListener(delegate
        {
            OnCharacterClicked?.Invoke();
            tabGroupMainButtons.DisplayButtonSelected(buttonCharacter.GetComponent<TabGroupButton>());
        });
        SaveSystem.OnAppStarted += delegate
        {
            tabGroupMainButtons.DisplayButtonSelected(buttonMenu.GetComponent<TabGroupButton>());
        };
        
    }
}
