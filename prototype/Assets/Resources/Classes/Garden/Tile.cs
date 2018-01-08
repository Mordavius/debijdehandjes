using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TileState { blank, raked, seeded }

public class Tile : MonoBehaviour
{
    public Plant plant;
    public int state;
    public int plantType;

    public Sprite sprite;

    private GameObject currentVegetable;
    public GameObject dragVegetable;

    void Start () {
        // to make testing easier
        state = 1;
    }
	
	void Update () {
        // check for state, if 2 it means seeds are on it
        if (state == (int)TileState.blank)
        {
            tag = "BlankGround";
            GetComponent<SpriteRenderer>().sprite = null;
        }
        if (state == (int)TileState.raked)
        {
            tag = "RakedGround";
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
        if (state == (int)TileState.seeded)
        {
            tag = "SeededGround";
            plant.GrowPlant(this);
        }
    }

    // these functions are for receiving vars from the seeds
    public void ChangeState(int newState)
    {
        state = newState;
    }

    public void SeedPlant(Plant newPlant)
    {
        plant = newPlant;
    }

    public void ChangeSprite(Sprite newSprite)
    {
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }

    void OnMouseDown()
    {
        if (state == (int)TileState.seeded)
        {
            if (plant.ready && state == (int)TileState.seeded)
            {
                currentVegetable = Instantiate(dragVegetable, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2)), new Quaternion(0, 0, 0, 0));
                currentVegetable.GetComponent<SpriteRenderer>().sprite = plant.plantSprite;
                currentVegetable.GetComponent<DraggingVegetable>().plant = plant;
                state = 0;
                plant = null;
                plantType = 0;
            }
        }
    }

    void OnMouseDrag()
    {
        if (currentVegetable)
        {
            Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint);
            currentVegetable.transform.position = cursorPosition;
        }
    }
}
