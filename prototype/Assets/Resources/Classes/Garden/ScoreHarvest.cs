using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHarvest : MonoBehaviour {

    private int scoreCount = 0;
    public Text scoreText;
    private Plant plant;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Seed")
        {

            scoreCount += plant.valueOfHarvest;
            scoreText.text = scoreCount.ToString();
            Destroy(other.gameObject);
        }
    }
}
