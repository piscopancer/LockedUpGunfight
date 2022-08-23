using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TriInspector;
using DG.Tweening;
using System;

public class PanelSettings : PanelBase
{
    const float TIME_ANIM = 0.15f;
    const float TRANSPARENCY_OFF = 0.25f;
    [SerializeField, Required] Button buttonClose, buttonSound, buttonMusic, buttonVibration, buttonEnglish, buttonRussian;
    [SerializeField, Required] CanvasGroup groupSound, groupMusic, groupVibration;
    [SerializeField, Required] Image imageEnglish, imageRussian;
    [SerializeField, Required] Button buttonVK, buttonGithub;

    public static Action OnSoundClicked, OnMusicClicked, OnVibrationClicked;
    public static Action<Languages> OnLanguageClicked;

    protected override void Awake()
    {
        base.Awake();

        buttonClose.onClick.AddListener(delegate
        {
            Close();
        });
        buttonSound.onClick.AddListener(delegate
        {
            OnSoundClicked?.Invoke();
            groupSound.DOFade(Audio.SoundOn ? 1 : TRANSPARENCY_OFF, TIME_ANIM);
        });
        buttonMusic.onClick.AddListener(delegate
        {
            OnMusicClicked?.Invoke();
            groupMusic.DOFade(Audio.MusicOn ? 1 : TRANSPARENCY_OFF, TIME_ANIM);
        });
        buttonVibration.onClick.AddListener(delegate
        {
            OnVibrationClicked?.Invoke();
            groupVibration.DOFade(Audio.VibraionOn ? 1 : TRANSPARENCY_OFF, TIME_ANIM);
        });
        buttonEnglish.onClick.AddListener(delegate
        {
            OnLanguageClicked?.Invoke(Languages.English);
            imageEnglish.DOFade(1, TIME_ANIM);
            imageRussian.DOFade(TRANSPARENCY_OFF, TIME_ANIM);
        });
        buttonRussian.onClick.AddListener(delegate
        {
            OnLanguageClicked?.Invoke(Languages.Russian);
            imageRussian.DOFade(1, TIME_ANIM);
            imageEnglish.DOFade(TRANSPARENCY_OFF, TIME_ANIM);
        });
        buttonVK.onClick.AddListener(delegate
        {
            Application.OpenURL("https://vk.com/piscopancer");
        });
        buttonGithub.onClick.AddListener(delegate
        {
            Application.OpenURL("https://github.com/piscopancer");
        });

        groupSound.DOFade(Audio.SoundOn ? 1 : TRANSPARENCY_OFF, TIME_ANIM);
        groupMusic.DOFade(Audio.MusicOn ? 1 : TRANSPARENCY_OFF, TIME_ANIM);
        groupVibration.DOFade(Audio.VibraionOn ? 1 : TRANSPARENCY_OFF, TIME_ANIM);
        imageEnglish.DOFade(Language.LanguageCurrent == Languages.English ? 1 : TRANSPARENCY_OFF, TIME_ANIM);
        imageRussian.DOFade(Language.LanguageCurrent == Languages.Russian ? 1 : TRANSPARENCY_OFF, TIME_ANIM);
    }
}
