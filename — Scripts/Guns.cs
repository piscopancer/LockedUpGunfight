using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;

public class Guns : MonoBehaviour
{
    public const int COUNT_LEVELS = 5;
    [Title("Levels")]
    [field: SerializeField, TableList(HideAddButton = true, HideRemoveButton = true)]
    public List<GunLevelVisuals> ListGunLevelVisuals { get; private set; } = new List<GunLevelVisuals>(COUNT_LEVELS)
    {
        new GunLevelVisuals(),
        new GunLevelVisuals(),
        new GunLevelVisuals(),
        new GunLevelVisuals(),
        new GunLevelVisuals()
    };
    [field: SerializeField, Range(1, COUNT_LEVELS)] public int LevelGiveLaserSight { get; private set; } = 1;
    [field: SerializeField, Range(1, COUNT_LEVELS)] public int LevelGiveSilencer { get; private set; } = 2;
    [Title("Guns")]
    [SerializeField] GunInfo gunDefault;
    [SerializeField] List<GunInfo> listGunsInfo;

    public static Action<GunInfo> OnGunEquipped;

    void Awake()
    {
            
    }

}

[Serializable]
public class GunInfo
{
    [field: SerializeField, Range(1, Guns.COUNT_LEVELS), EnableIf(nameof(IsBought))] public int Level = 1; 
    [field: SerializeField] public bool IsBought = false;
    [field: SerializeField, ReadOnly] public bool IsEquipped = false;
    [field: SerializeField, Required, InlineEditor] public GunProfileBase Profile { get; private set; }
}

[Serializable]
public class GunLevelVisuals
{
    [field: SerializeField, Required, InlineEditor] public Translation Name { get; private set; }
    [field: SerializeField] public Color ColorRarity { get; private set; }
}
