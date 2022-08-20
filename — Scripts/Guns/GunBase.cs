using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;

public abstract class GunBase : MonoBehaviour
{
    [SerializeField, Required, InlineEditor] GunProfileBase profile;
    [SerializeField, Required] Transform muzzle;
    [SerializeField, Required]
    List<GameObject> listGunLevelModels = new List<GameObject>(Guns.COUNT_LEVELS);

    protected virtual void Shoot()
    {

    }

    public void DisplayModel(int level)
    {
        foreach (var model in listGunLevelModels)
        {
            model.SetActive(false);
        }
        listGunLevelModels[level].SetActive(true);
    }
}

