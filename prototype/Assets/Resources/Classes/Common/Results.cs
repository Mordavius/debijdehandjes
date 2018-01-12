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
    string score;
    string currentHighestScoreString;
    string[] scores;
    string scoreList;
    string dateList;
    string timeList;
    public GameManager gameManager;
    string keyName;

    // Use this for initialization
    void Start () {
        levelName = SceneManager.GetActiveScene().name;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        keyName = levelName + "-score-" + gameManager.gameManagerAccountID;
        scoreList = PlayerPrefs.GetString(keyName);
        
        multiplier = multiplier - (Time.timeSinceLevelLoad * 0.05f);
        if (multiplier <= 1)
        {
            multiplier = 1;
        }
        score = (baseScore * multiplier).ToString();
        behaaldeScore.text = score;
        PlayerPrefs.SetString(keyName, scoreList + " " + score);
        PlayerPrefs.SetString(levelName+ "-date-" + gameManager.gameManagerAccountID, dateList + " " + DateTime.Today.ToString("dd/MM/yyyy"));
        PlayerPrefs.SetString(levelName + "-time-" + gameManager.gameManagerAccountID, timeList + " " + Time.timeSinceLevelLoad.ToString());
        hoogsteScore.text = GetHighestScore();
	}

    string GetHighestScore()
    {
        float currentScore = 0.0f;
        float highestScore = 0.0f;
        scores = PlayerPrefs.GetString(keyName).Split(' ');
        foreach (string gottenScore in scores)
        {
            float.TryParse(gottenScore, out currentScore);
            //if (float.Parse(gottenScore, CultureInfo.InvariantCulture.NumberFormat) > currentHighestScore)
            if (highestScore < currentScore)
            {
                highestScore = currentScore;
                currentHighestScoreString = highestScore.ToString();
            }
            }
        return currentHighestScoreString;
        }
	
	// Update is called once per frame
	void Update () {
		
	}
}
