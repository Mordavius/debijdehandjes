using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitorViewReplace : MonoBehaviour {

    public Text scores;
    public Text times;
    public Text dates;
    public Text levelSelect;
    public Text userSelect;
    //string accountName;

    // Use this for initialization
    void Start() {
        ShowData();
    }

    // Update is called once per frame
    void Update() {

    }

    public void ShowData() {
        scores.text = "";
        times.text = "";
        dates.text = "";
        SetDateText(userSelect.text, levelSelect.text);
        SetScoreText(userSelect.text, levelSelect.text);
        SetTimeText(userSelect.text, levelSelect.text);
    }

    public void SetDateText(string userSelect, string levelSelect)
    {
        string[] gottenDates = PlayerPrefs.GetString(levelSelect + "-date-" + userSelect).Split(' ');
        foreach (string date in gottenDates)
        {
            dates.text += date + "\n";
        }
    }

    public void SetScoreText(string userSelect, string levelSelect)
    {
        string[] gottenScores = PlayerPrefs.GetString(levelSelect + "-score-" + userSelect).Split(' ');
        foreach (string score in gottenScores)
        {
            scores.text += score + "\n";
        }
    }

    public void SetTimeText(string userSelect, string levelSelect)
    {
        string[] gottenTimes = PlayerPrefs.GetString(levelSelect + "-time-" + userSelect).Split(' ');
        Debug.Log(PlayerPrefs.GetString(userSelect + "-time-" + levelSelect));
        foreach (string time in gottenTimes)
        {
            
            times.text += time + "\n";
        }
    }
}
