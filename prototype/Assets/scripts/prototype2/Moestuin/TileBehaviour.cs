﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TileState { blank, raked, seeded }

public class TileBehaviour : MonoBehaviour
{
    Plant plant;
    public int state;
    public int plantType;

    public Sprite[] sprite;

	void Start () {
        // to make testing easier
        state = 0;
    }
	
	void Update () {
        // check for state, if 2 it means seeds are on it
        if (state == (int)TileState.blank || state == (int)TileState.raked)
        {
            GetComponent<SpriteRenderer>().sprite = sprite[state];
        }
        //TODO: create new gameObject with seed
        if (state == (int)TileState.seeded)
        {
            plant.Grow();
        }
    }

    // these functions are for receiving vars from the seeds
    void ChangeState(int newState)
    {
        state = newState;
    }

    void SeedPlant(Plant newPlant)
    {
        plant = newPlant;
        Debug.Log(plant.score);
    }
}
