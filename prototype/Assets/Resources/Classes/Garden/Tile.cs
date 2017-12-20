using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TileState { blank, raked, seeded }

public class Tile : MonoBehaviour
{
    Plant plant;
    public int state;
    public int plantType;

    public Sprite[] sprite;

	void Start () {
        // to make testing easier
        state = 1;
    }
	
	void Update () {
        // check for state, if 2 it means seeds are on it
        if (state == (int)TileState.blank || state == (int)TileState.raked)
        {
            GetComponent<SpriteRenderer>().sprite = sprite[state];
        }
        if (state == (int)TileState.raked)
        {
            tag = "RakedGround";
        }
        //TODO: create new gameObject with seed
        if (state == (int)TileState.seeded)
        {
            plant.GrowPlant(this);
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
    }

    public void ChangeSprite(Sprite newSprite)
    {
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "WC" && state == 2)
        {
            plant.GetWatered();
        }
    }
}
