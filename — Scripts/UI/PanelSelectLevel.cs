using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;
using UnityEngine.UI;

public class PanelSelectLevel : PanelBase
{
    [SerializeField, Required] Button buttonClose; 
    [SerializeField, Required] LayoutGroup holderButtonsLevels;
    [SerializeField, Required] ButtonSelectLevel prefabButtonSelectLevel;

    protected override void Awake()
    {
        base.Awake();

        buttonClose.onClick.AddListener(delegate
        {
            Close();
        });

        SetupButtons();
    }

    void SetupButtons()
    {
        if (holderButtonsLevels.transform.childCount > 0)
        {
            foreach (Transform button in holderButtonsLevels.transform)
            {
                Destroy(button.gameObject);
            }
        }
        for (int i = 0; i < GameModeLevels.ListLevels.Count; i++)
        {
            var button = Instantiate(prefabButtonSelectLevel, holderButtonsLevels.transform);
            button.Setup(i, GameModeLevels.ListLevels[i]);
        }
    }
}
