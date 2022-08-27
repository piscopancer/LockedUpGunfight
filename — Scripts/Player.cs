using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;

public class Player : MonoBehaviour, ITemporarySubscriber
{
    [SerializeField, Required] Transform posGun;
    [SerializeField, ReadOnly] GunProfile gunDisplayed = null;

    void Awake()
    {
        Subscribe();
    }

    void OnDestroy()
    {
        Unsubscribe();
    }

    public void Subscribe()
    {
        Guns.OnGunEquipped += delegate (GunStatus gun)
        {
            DisplayGun(gun.Profile);
        };
    }

    public void Unsubscribe()
    {
        
    }

    public void DisplayGun(GunProfile gunProfile)
    {
        if (gunDisplayed)
        {
            Destroy(posGun.GetChild(0).gameObject);
        }
        Instantiate(gunProfile.Gun, posGun);
        gunDisplayed = gunProfile;
    }

}
