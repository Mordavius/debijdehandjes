using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitorView : MonoBehaviour {

    public Text[] scores = new Text[6];
    public Text[] times = new Text[6];
    public Text[] dates = new Text[6];
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
        
        for (int i = 0; i < 6; i++)
        {
            scores[i].text = GetScores(userSelect.text, levelSelect.text)[i];
            times[i].text = GetTimes(userSelect.text, levelSelect.text)[i];
            dates[i].text = GetDates(userSelect.text, levelSelect.text)[i];
        }
    }

    public string[] GetDates(string userSelect, string levelSelect){
        int j = 0;
        string[] dates = new string[6];
        string[] dateList = PlayerPrefs.GetString(levelSelect + "-date-" + userSelect).Split(' ');
        /*for (int i = PlayerPrefs.GetString(userSelect + "-" + levelSelect + "-dates").Length - 6; i <= PlayerPrefs.GetString(userSelect + "-" + levelSelect + "-dates").Length; i++)
        {

        }*/
        for (int i = (dateList.Length - 6); i <= (dateList.Length -1); i++)
        {
            dates[j] = dateList[i];
            j++;
        }
        return dates;
    }
    //keyName = levelName + "-score-" + gameManager.gameManagerAccountID;
    public string[] GetTimes(string userSelect, string levelSelect){
        int j = 0;
        string[] times = new string[6];
        string[] timesList = PlayerPrefs.GetString(levelSelect + "-time-" + userSelect).Split(' ');
        /*for (int i = PlayerPrefs.GetString(userSelect + "-" + levelSelect + "-dates").Length - 6; i <= PlayerPrefs.GetString(userSelect + "-" + levelSelect + "-dates").Length; i++)
        {

        }*/
        for (int i = (timesList.Length - 6); i <= (timesList.Length -1); i++)
        {
            times[j] = timesList[i];
            j++;
        }
        return times;
    }

    public string[] GetScores(string userSelect, string levelSelect){
        int j = 0;
        string[] newScores = new string[6];
        string[] scoresList = PlayerPrefs.GetString(levelSelect + "-score-" + userSelect).Split(' ');
        /*for (int i = PlayerPrefs.GetString(userSelect + "-" + levelSelect + "-dates").Length - 6; i <= PlayerPrefs.GetString(userSelect + "-" + levelSelect + "-dates").Length; i++)
        {

        }*/
        for (int i = (scoresList.Length - 6); i <= (scoresList.Length -1); i++)
        {
            newScores[j] = scoresList[i];
            j++;
        }
        return newScores;
    }
}
