using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public GameObject tutorialCanvas;
    public GameObject[] stepImage;
    public GameObject[] stepProgression;
    public bool isActive;
    public int step = 1;

	public void StartTutorial()
    {
        isActive = true;
    }

    public void CloseTutorial()
    {
        Debug.Log("CloseTutorial");
        for (int i = 1; i < stepImage.Length; i++)
        {
            stepImage[i].SetActive(false);
        }
        isActive = false;
    }

    void Update()
    {
        if (isActive)
        {
            switch (step)
            {
                default:
                    break;

                case 1:
                    for (int i = 1; i < stepImage.Length; i++)
                    {
                        stepImage[i].SetActive(false);
                    }
                    stepImage[1].SetActive(true);
                    RaycastHit2D hitRake = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                    if (hitRake.collider.CompareTag("toggleRake"))
                    {
                        step = 2;
                    }
                    break;

                case 2:
                    for (int i = 1; i < stepImage.Length; i++)
                    {
                        stepImage[i].SetActive(false);
                    }
                    stepImage[2].SetActive(true);
                    if (stepProgression[1].GetComponent<Tile>().state == TileState.raked)
                    {
                        step = 3;
                    }
                    break;

                case 3:
                    for (int i = 1; i < stepImage.Length; i++)
                    {
                        stepImage[i].SetActive(false);
                    }
                    stepImage[3].SetActive(true);
                    if (stepProgression[1].GetComponent<Tile>().state == TileState.seeded)
                    {
                        step = 4;
                    }
                    break;

                case 4:
                    for (int i = 1; i < stepImage.Length; i++)
                    {
                        stepImage[i].SetActive(false);
                    }
                    stepImage[4].SetActive(true);
                    if (stepProgression[1].GetComponent<Tile>().plant.isWatered)
                    {
                        step = 5;
                    }
                    break;

                case 5:
                    for (int i = 1; i < stepImage.Length; i++)
                    {
                        stepImage[i].SetActive(false);
                    }
                    stepImage[5].SetActive(true);
                    if (stepProgression[1].GetComponent<Tile>().state == TileState.blank && GameObject.FindGameObjectWithTag("vegetable") == null)
                    {
                        CloseTutorial();
                        step = 1;
                    }
                    break;
            }
        }
    }
}
