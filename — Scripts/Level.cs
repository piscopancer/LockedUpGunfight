using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TriInspector;

public class Level : MonoBehaviour
{
    [field: SerializeField, Required, InlineEditor] public Translation TranslationLevelName { get; private set;}
    [field: SerializeField, Required, InlineEditor] public Translation TranslationLevelComment { get; private set;}
    [field: SerializeField, Min(0)] public int Time1Medal { get; private set; } = 30;
    [field: SerializeField, Min(0)] public int Time2Medal { get; private set; } = 45;
    [field: SerializeField, Min(0)] public int Time3Medal { get; private set; } = 60;
    [field: SerializeField] public List<Enemy> ListEnemies { get; private set; }

    public void FinishSuccess()
    {

    }

    public void FinishFailed()
    {

    }
}
