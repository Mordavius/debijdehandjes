using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCards : MonoBehaviour {

    List<int> cardStore = new List<int> { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
    List<int> cardActive = new List<int>();

    public GameObject[] card;

    private float xPos = 0;

    private GameObject yesButton;
    private bool buttonPressed = false;

    void Start()
    {
        yesButton = GameObject.Find("StartCanvas");
    }

    void Update () {
        buttonPressed = yesButton.GetComponent<MemoryLevel>().buttonPressed;

        if (buttonPressed)
        {
            for (int i = 0; i < 12; i++)
            {
                int randomIndex = Random.Range(0, cardStore.Count);
                cardActive.Add(cardStore[randomIndex]);
                cardStore.RemoveAt(randomIndex);
            }
            int cardCount = 0;
            for (int yPos = 0; yPos < 3; yPos++)
            {
                Instantiate(card[cardActive[cardCount]], new Vector3(xPos, yPos, 0), new Quaternion(0, 0, 0, 0));
                cardCount++;
                for (int xPos = 1; xPos < 4; xPos++)
                {
                    Instantiate(card[cardActive[cardCount]], new Vector3(xPos, yPos, 0), new Quaternion(0, 0, 0, 0));
                    cardCount++;
                }
            }
            yesButton.GetComponent<MemoryLevel>().buttonPressed = false;
            buttonPressed = false;
        }
	}
}
