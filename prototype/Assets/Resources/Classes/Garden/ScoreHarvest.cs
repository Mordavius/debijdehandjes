using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHarvest : MonoBehaviour {

    public int scoreCount = 0;
    public Text scoreText;
    private Plant plant;

    void Start()
    {
        if (PlayerPrefs.GetInt("score") != 0)
        {
            scoreCount = PlayerPrefs.GetInt("score");
        }
        scoreText.text = scoreCount.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Seed")
        {
            plant = other.GetComponent<DraggingVegetable>().plant;
            scoreCount += plant.valueOfHarvest;
            scoreText.text = "€" + scoreCount.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("nl-NL")); ;
            Destroy(other.gameObject);
        }
    }
}
