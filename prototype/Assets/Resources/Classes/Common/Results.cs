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
    float currentHighestScore;
    string levelName;
    string score;
    string currentHighestScoreString;
    string[] scores;
    string scoreList;
    public GameManager gameManager;
    string keyName;

    // Use this for initialization
    void Start () {
        currentHighestScore = 0;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        keyName = levelName + "-score-" + gameManager.gameManagerAccountID;
        scoreList = PlayerPrefs.GetString(keyName);
        levelName = SceneManager.GetActiveScene().name;
        multiplier = multiplier - (Time.timeSinceLevelLoad * 0.05f);
        if (multiplier <= 1)
        {
            multiplier = 1;
        }
        score = (baseScore * multiplier).ToString();
        behaaldeScore.text = score;
        PlayerPrefs.SetString(keyName, scoreList + " " + score);
        hoogsteScore.text = GetHighestScore();
	}

    string GetHighestScore()
    {
        scores = PlayerPrefs.GetString(keyName).Split(' ');
        foreach (string gottenScore in scores)
        {
            if (float.Parse(gottenScore, CultureInfo.InvariantCulture.NumberFormat) > currentHighestScore)
            {
                currentHighestScore = float.Parse(gottenScore, CultureInfo.InvariantCulture.NumberFormat);
                currentHighestScoreString = gottenScore;
            }
            }
        return currentHighestScoreString;
        }
	
	// Update is called once per frame
	void Update () {
		
	}
}
