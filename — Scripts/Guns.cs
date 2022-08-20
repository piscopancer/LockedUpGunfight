using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;

public class Guns : MonoBehaviour
{
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
    [field: SerializeField] public bool IsBought { get; private set; } = false;
    [field: SerializeField, ReadOnly] public bool IsEquipped { get; private set; } = false;
    [field: SerializeField, Required] public GunProfileBase Profile { get; private set; }
}


