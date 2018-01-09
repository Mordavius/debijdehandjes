using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileState { blank, raked, seeded }

public class Tile : MonoBehaviour
{
    public Plant plant;
    public TileState state;

    public Sprite sprite;

    private GameObject currentVegetable;
    public GameObject dragVegetable;

    void Start () {
        // to make testing easier
        state = TileState.raked;
    }
	
	void Update () {
        if (state == TileState.blank)
        {
            tag = "BlankGround";
            GetComponent<SpriteRenderer>().sprite = null;
        }
        if (state == TileState.raked)
        {
            tag = "RakedGround";
            GetComponent<SpriteRenderer>().sprite = sprite;
        }
        if (state == TileState.seeded)
        {
            tag = "SeededGround";
            plant.GrowPlant(this);
        }
    }

    // these functions are for receiving vars from the seeds
    public void ChangeState(TileState newState)
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
        if (state == TileState.seeded)
        {
            if (plant.ready && state == TileState.seeded)
            {
                currentVegetable = Instantiate(dragVegetable, Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2)), new Quaternion(0, 0, 0, 0));
                currentVegetable.GetComponent<SpriteRenderer>().sprite = plant.plantSprite;
                currentVegetable.GetComponent<DraggingVegetable>().plant = plant;
                state = 0;
                plant = null;
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
