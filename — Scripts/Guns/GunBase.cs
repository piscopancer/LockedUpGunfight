using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;

public abstract class GunBase : MonoBehaviour
{
    [SerializeField, Required] GunProfileBase profile;
    [SerializeField, Required] Transform muzzle;

    protected virtual void Shoot()
    {

    }
}
