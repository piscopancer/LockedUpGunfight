using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Custom Color")]
public class ColorCustom : ScriptableObject
{
    [field: SerializeField] public Color Color { get; private set; } = Color.white;
}
