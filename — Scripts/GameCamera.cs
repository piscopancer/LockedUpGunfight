using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using DG.Tweening;

public class GameCamera : MonoBehaviour
{
    const float ANIM_TIME = 0.5f;
    [SerializeField] CameraPreset presetMenu, presetGuns, presetCharacter;

    void Awake()
    {
        SaveSystem.OnAppStarted += delegate
        {
            LoadCameraPreset(presetMenu);
        };
        PanelDockBottom.OnGunsClicked += delegate
        {
            LoadCameraPreset(presetGuns);
        };
        PanelDockBottom.OnMenuClicked += delegate
        {
            LoadCameraPreset(presetMenu);
        };
        PanelDockBottom.OnCharacterClicked += delegate
        {
            LoadCameraPreset(presetCharacter);
        };
    }

    void LoadCameraPreset(CameraPreset preset)
    {
        GetComponent<Camera>().transform.DOMove(preset.Transform.position, ANIM_TIME);
        GetComponent<Camera>().transform.DORotateQuaternion(preset.Transform.rotation, ANIM_TIME);
        GetComponent<Camera>().DOFieldOfView(preset.FOV, ANIM_TIME);
    }
}

[System.Serializable]
public class CameraPreset
{
    [field: SerializeField, Required, InlineEditor] public Transform Transform { get; private set; }
    [field: SerializeField, Range(1, 90)] public int FOV { get; private set; } = 40;
}
