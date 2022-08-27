using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;

public class Guns : MonoBehaviour
{
    [SerializeField] GunStatus gunDefault;
    public static GunStatus GunDefault
    {
        get
        {
            return FindObjectOfType<Guns>().gunDefault;
        }
    }
    public static GunStatus GunEquipped
    {
        get
        {
            foreach (var gun in ListGuns)
            {
                if (gun.IsEquipped)
                {
                    return gun;
                }
            }
            return GunDefault;
        }
        set
        {
            foreach (var gun in ListGuns)
            {
                if (gun.Profile != value.Profile)
                {
                    gun.IsEquipped = false;
                }
                if (gun.Profile == value.Profile)
                {
                    gun.IsEquipped = true;
                    OnGunEquipped?.Invoke(value);
                }
            }
        }
    }
    [SerializeField] List<GunStatus> listGuns;
    public static List<GunStatus> ListGuns
    {
        get
        {
            return FindObjectOfType<Guns>().listGuns;
        }
        set
        {
            FindObjectOfType<Guns>().listGuns = value;
        }
    }
    public static Action<GunStatus> OnGunEquipped;

    void Awake()
    {
        SaveSystem.OnSaveDoesNotExist += delegate
        {
            GunEquipped = GunDefault;
        };
        SaveSystem.OnSaveLoaded += delegate (SaveSystem.SaveData save)
        {
            ListGuns = save.ListGuns;
            GunEquipped = save.GunEquipped;
        };
    }

}

[Serializable]
public class GunStatus
{
    [field: SerializeField] public bool IsBought = false;
    [field: SerializeField, ReadOnly] public int LevelCurrent = 1;
    [field: SerializeField, ReadOnly] public bool IsEquipped = false;
    [field: SerializeField, Required, InlineEditor] public GunProfile Profile { get; private set; }
}
