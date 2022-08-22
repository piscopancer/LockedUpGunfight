using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using System;

public class Balance : MonoBehaviour
{
    [SerializeField] int dollars;
    public static int Dollars
    {
        get
        {
            return FindObjectOfType<Balance>().dollars;
        }
        set
        {
            FindObjectOfType<Balance>().dollars = value;
        }
    }

    public static Action<int, int> OnDollarsChangedBy;

    void Awake()
    {
            
    }

    void ChangeDollarsBy(int count)
    {
        dollars -= count;
        OnDollarsChangedBy?.Invoke(dollars, count);
    }
}
