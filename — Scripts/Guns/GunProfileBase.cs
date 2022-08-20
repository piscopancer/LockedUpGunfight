using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;

public class GunProfileBase : ScriptableObject
{
    [field: SerializeField, Required, InlineEditor] public Translation Name { get; private set; }
    [field: SerializeField, TableList(HideAddButton = true, HideRemoveButton = true)]
    public List<GunLevel> ListGunLevels = new List<GunLevel>(5)
    {
        new GunLevel(),
        new GunLevel(),
        new GunLevel(),
        new GunLevel(),
        new GunLevel()
    };

    [Serializable]
    public class GunLevel
    {
        [field: SerializeField, Min(0)] public int Damage { get; private set; } = 50;
        [field: SerializeField, Min(0)] public int RPM { get; set; } = 200;
        [field: SerializeField, Range(0, 100)] public int Accuracy { get; private set; } = 80;
        [field: SerializeField, Min(0)] public int KillsToNextLevel { get; private set; } = 100;
    }
}



