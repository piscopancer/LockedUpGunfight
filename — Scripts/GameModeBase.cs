using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;

public abstract class GameModeBase : MonoBehaviour
{
    public static Action<GameModeBase> OnGameModeSelected, OnGameStarted;
}
