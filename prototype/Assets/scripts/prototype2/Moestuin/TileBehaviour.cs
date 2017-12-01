using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    Plant plant;
    public int state;
    public int plantType;
    
    public float growth;
    public float growthMultiplier;
    public int score;

    public Sprite[] sprite;

    /* state
     * 0 = empty tile
     * 1 = raked
     * 2 = seeded
     */

	void Start () {
        // to make testing easier
        state = 0;
    }
	
	void Update () {
        // check for state, if 2 it means seeds are on it, then check what seed
        if (state == 0 || state == 1)
        {
            GetComponent<SpriteRenderer>().sprite = sprite[state];
        }
        //TODO: create new gameObject with seed
        //Debug.Log(growth -= Time.deltaTime);

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
