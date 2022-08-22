using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    const string SAVE_FILE_NAME = "Save";
    string fullPath = null;

    public static Action OnAppStarted;
    public static Action OnSaveDoesNotExist;
    public static Action<SaveData> OnSaveLoaded;

    void Awake()
    {
        PanelMenu.OnQuitClicked += delegate
        {
            Save();
            Application.Quit();
        }; 
    }

    void Start()
    {
        OnAppStarted?.Invoke();
        Load();
        fullPath = $"{Application.persistentDataPath}/{SAVE_FILE_NAME}.json";
    }

    public class SaveData
    {
        public Languages LanguageCurrent;
        public bool SoundOn, MusicOn, VibrationOn;
        public int Dollars;
    }

    void Save()
    {
        SaveData save = new SaveData
        {
            LanguageCurrent = Language.LanguageCurrent,
            SoundOn = Audio.SoundOn,
            MusicOn = Audio.MusicOn,
            VibrationOn = Audio.VibraionOn,
            Dollars = Balance.Dollars
        };
        string saveText = JsonUtility.ToJson(save, true);
        using StreamWriter sw = new StreamWriter(fullPath);
        sw.Write(saveText);
        sw.Close();
    }

    void Load()
    {
        if (!File.Exists(fullPath))
        {
            OnSaveDoesNotExist?.Invoke();
            return;
        }
        using StreamReader sr = new StreamReader(fullPath);
        string saveText = sr.ReadToEnd();
        SaveData save = JsonUtility.FromJson<SaveData>(saveText);
        OnSaveLoaded?.Invoke(save);
    }
}
