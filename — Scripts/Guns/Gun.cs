using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;

public class Gun : MonoBehaviour
{
    [SerializeField, Required, InlineEditor] GunProfile profile;
    [SerializeField, Required] Transform muzzle;

    protected virtual void Shoot()
    {

    }
}

