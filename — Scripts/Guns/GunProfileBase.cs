using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;

public class GunProfileBase : ScriptableObject
{
    [field: SerializeField, Min(0)] public int Damage { get; private set; } = 1;
    [field: SerializeField, Min(0)] public int RPM { get; set; } = 200;
    [field: SerializeField, Range(0, 100)] public int Accuracy { get; private set; } = 90;
    public const int COUNT_LEVELS = 4;
    [field: SerializeField, Range(1, COUNT_LEVELS)] public int LevelGiveLaserSight { get; private set; } = 1;
    [field: SerializeField, Range(1, COUNT_LEVELS)] public int LevelGiveSilencer { get; private set; } = 2;
    [field: SerializeField, ListDrawerSettings(HideAddButton = true, HideRemoveButton = true)]
    public List<GunLevel> ListGunLevels { get; private set; } = new List<GunLevel>(COUNT_LEVELS);
}

[Serializable]
public class GunLevel
{
    [field: SerializeField] public Color ColorRarity { get; private set; } = Color.white;
    [field: SerializeField, Min(0)] public int KillsToNextLevel { get; private set; } = 100;
    [field: SerializeField, Min(0)] public int IncreaseDamageBy { get; private set; } = 0;
    [field: SerializeField, Min(0)] public int IncreaseAccuracyBy { get; private set; } = 0;
}
