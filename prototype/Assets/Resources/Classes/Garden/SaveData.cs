using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour {

    public GameObject scoreGameObject;
    private GameManager GameManager;
    int score;

    public void SaveAndExit()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        score = scoreGameObject.GetComponent<ScoreHarvest>().scoreCount;
        GameManager.SaveAccountScoreData(score);
        SceneManager.LoadScene("mainmenu");
    }
}
