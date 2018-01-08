using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour {

    public GameObject scoreGameObject;
    int score;

	public void SaveAndExit()
    {
        score = scoreGameObject.GetComponent<ScoreHarvest>().scoreCount;
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
        SceneManager.LoadScene("mainmenu");
    }
}
