using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;

public class Audio : MonoBehaviour
{
    [SerializeField] bool soundOn, musicOn, vibrationOn;
    public static bool SoundOn
    {
        get
        {
            return FindObjectOfType<Audio>().soundOn;
        }
        set
        {
            FindObjectOfType<Audio>().soundOn = value;
        }
    }
    public static bool MusicOn
    {
        get
        {
            return FindObjectOfType<Audio>().musicOn;
        }
        set
        {
            FindObjectOfType<Audio>().musicOn = value;
        }
    }
    public static bool VibraionOn
    {
        get
        {
            return FindObjectOfType<Audio>().vibrationOn;
        }
        set
        {
            FindObjectOfType<Audio>().vibrationOn = value;
        }
    }

    void Awake()
    {
        SaveSystem.OnSaveLoaded += delegate (SaveSystem.SaveData save)
        {
            SoundOn = save.SoundOn;
            MusicOn = save.MusicOn;
            VibraionOn = save.VibrationOn;
        };
        PanelSettings.OnSoundClicked += delegate
        {
            SoundOn = !SoundOn;
        };
        PanelSettings.OnMusicClicked += delegate
        {
            MusicOn = !MusicOn;
        };
        PanelSettings.OnVibrationClicked += delegate
        {
            VibraionOn = !VibraionOn;
        };
    }
}
