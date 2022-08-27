using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeInfinite : GameModeBase
{
    void Awake()
    {
        PanelMenu.OnInfiniteClicked += delegate
        {
            StartGame();
        };
    }
}
