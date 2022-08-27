using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TriInspector;
using UnityEngine.UI;
using TMPro;
using System;

[RequireComponent(typeof(Button))]
public class ButtonSelectLevel : MonoBehaviour
{
    [SerializeField, Required] TextWithTranslation textLevelName, textLevelComment;
    [SerializeField, Required] TextMeshProUGUI textLevelNumber, 
        textTime1Medal, textTime2Medal, textTime3Medal, textTimeBest;
    [SerializeField, Required] Image imageMedal1, imageMedal2, imageMedal3;

    public static Action<int> OnClicked;

    public void Setup(int indexLevel, LevelStatus levelStatus)
    {
        int levelNumber = indexLevel + 1;
        string stringLevelNumber = "";
        stringLevelNumber += levelNumber < 10 ? "0" : "";
        stringLevelNumber += levelNumber.ToString();
        textLevelNumber.text = stringLevelNumber;
        textLevelName.SetText(levelStatus.Level.TranslationLevelName);
        textLevelComment.SetText(levelStatus.Level.TranslationLevelComment);
        textTime1Medal.text = IntToMinSec(levelStatus.Level.Time1Medal);
        textTime2Medal.text = IntToMinSec(levelStatus.Level.Time2Medal);
        textTime3Medal.text = IntToMinSec(levelStatus.Level.Time3Medal);
        textTimeBest.text = IntToMinSec(levelStatus.TimeBest);
        imageMedal1.gameObject.SetActive(levelStatus.CountMedals >= 1);
        imageMedal2.gameObject.SetActive(levelStatus.CountMedals >= 2);
        imageMedal3.gameObject.SetActive(levelStatus.CountMedals == 3);
        GetComponent<Button>().onClick.AddListener(delegate
        {
            OnClicked?.Invoke(indexLevel);
        });
    }

    string IntToMinSec(int time)
    {
        var minutesInt = Mathf.Floor(time / (float)60);
        var secondsInt = time - minutesInt * 60;
        string minutes = (minutesInt < 10 ? "0" : "") + minutesInt.ToString();
        string seconds = (secondsInt < 10 ? "0" : "") + secondsInt.ToString();
        return $"{minutes}:{seconds}";
    }
}
