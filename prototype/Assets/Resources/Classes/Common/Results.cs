using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Results : MonoBehaviour {
    public Text behaaldeScore;
    public Text hoogsteScore;
    public float baseScore;
    public float multiplier;
    string levelName;
    float score;
    int scoreInt;
    int timeInt;
    string currentHighestScoreString;
    string[] scores;
    string scoreList;
    string dateList;
    string timeList;
    public GameManager gameManager;
    string scoreKey;
    string timeKey;
    string dateKey;

    // Use this for initialization
    void Start () {
        levelName = SceneManager.GetActiveScene().name;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        scoreKey = levelName + "-score-" + gameManager.gameManagerAccountID;
        timeKey = levelName + "-time-" + gameManager.gameManagerAccountID;
        dateKey = levelName + "-date-" + gameManager.gameManagerAccountID;
        scoreList = PlayerPrefs.GetString(scoreKey);
        dateList = PlayerPrefs.GetString(dateKey);
        timeList = PlayerPrefs.GetString(timeKey);
        
        multiplier = multiplier - (Time.timeSinceLevelLoad * 0.05f);
        if (multiplier <= 1)
        {
            multiplier = 1;
        }
        score = baseScore * multiplier;
        scoreInt = (int)score;
        timeInt = (int)Time.timeSinceLevelLoad;
        behaaldeScore.text = scoreInt.ToString();
        PlayerPrefs.SetString(scoreKey, scoreList + " " + scoreInt.ToString());
        PlayerPrefs.SetString(dateKey, dateList + " " + DateTime.Today.ToString("dd/MM/yyyy"));
        PlayerPrefs.SetString(timeKey, timeList + " " + timeInt.ToString() + "s");
        hoogsteScore.text = GetHighestScore();
	}

    string GetHighestScore()
    {
        float currentScore = 0.0f;
        float highestScore = 0.0f;
        scores = PlayerPrefs.GetString(scoreKey).Split(' ');
        foreach (string gottenScore in scores)
        {
            float.TryParse(gottenScore, out currentScore);
            if (highestScore < currentScore)
            {
                highestScore = (int)currentScore;
                currentHighestScoreString = highestScore.ToString();
            }
            }
        return currentHighestScoreString;
        }
	
	// Update is called once per frame
	void Update () {
		
	}
}
