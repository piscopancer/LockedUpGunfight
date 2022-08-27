using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TriInspector;

public class GameModeLevels : GameModeBase
{
    [SerializeField] List<LevelStatus> listLevels;
    public static List<LevelStatus> ListLevels
    {
        get
        {
            return FindObjectOfType<GameModeLevels>().listLevels;
        }
    }

    public static Action<LevelStatus> OnLevelStarted, OnLevelCompleted, OnLevelFailed;

    void Awake()
    {
        ButtonSelectLevel.OnClicked += delegate (int levelIndex)
        {
            StartLevel(levelIndex);
        };
    }

    void StartLevel(int index)
    {
        var level = ListLevels[index];
        OnLevelStarted?.Invoke(level);
    }
}

[Serializable]
public class LevelStatus
{
    [field: SerializeField, ReadOnly] public int CountMedals { get; private set; }
    public bool IsCompleted
    {
        get
        {
            return CountMedals >= 1;
        }
    } 
    [field: SerializeField, ReadOnly] public int TimeBest { get; private set; } 
    [field: SerializeField, Required, InlineEditor] public Level Level { get; private set; }
}
