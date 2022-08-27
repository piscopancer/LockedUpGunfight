using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TriInspector;
using System;

public class PanelDockBottom : PanelBase, ITemporarySubscriber
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

        Subscribe();

        tabGroupMainButtons.DisplayButtonSelected(buttonMenu.GetComponent<TabGroupButton>());
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
        if (panelOpened is PanelSettings
            || panelOpened is PanelSelectLevel)
        {
            Close();
        }
    }
}
