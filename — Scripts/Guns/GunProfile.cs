using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;

[DeclareBoxGroup("Level", Title = "Level")]
[DeclareBoxGroup("General", Title = "General")]
[CreateAssetMenu(menuName = "Guns/New Gun")]
public class GunProfile : ScriptableObject
{
    public enum GunTypes { Pistol, Shotgun, MachinePistol, AssaultRifle, SniperRifle, MachineGun }

    [field: SerializeField, Group("General")] public GunTypes GunType { get; private set; } = GunTypes.Pistol;
    [field: SerializeField, Group("General"), Required, InlineEditor] public Translation Name { get; private set; }
    [field: SerializeField, Group("General"), Required] public Gun Gun { get; private set; } 
    [field: SerializeField, Group("General"), Min(0)] public int DamageBase { get; private set; } = 50;
    [field: SerializeField, Group("General"), Min(0)] public int RPM { get; set; } = 200;
    [field: SerializeField, Group("General"), Range(0, 100)] public int Accuracy { get; private set; } = 80;
    const int LEVEL_MAX = 30;
    [field: SerializeField, Group("Level"), Min(0)] public int DamageBonusPerLevel { get; private set; } = 1;
    const int XP_INCREASE_PER_LEVEL = 10;
}



