using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTouch : MonoBehaviour {

    public string plantName;
    public Plant plant;
    public Sprite[] sprite;

    void Start()
    {
        Type type = Type.GetType(plantName);
        if (type == null)
        {
            Debug.Log("This plant name does not exist! \nUsing Carrot as default.");
            type = Type.GetType("Carrot");
        }
        plant = (Plant)Activator.CreateInstance(type);
        GetComponent<SpriteRenderer>().sprite = plant.seedSprite;
    }
    
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit && Input.GetMouseButtonUp(0))
        {
            if (hit.collider.tag != "RakedGround" || hit.collider.tag == null)
            {
                Destroy(this.gameObject);
            }
            if (hit.collider.tag == "RakedGround")
            {
                Tile tilePlacedOn = hit.collider.GetComponent<Tile>();
                if (tilePlacedOn.state == TileState.raked)
                {
                    hit.transform.SendMessageUpwards("SeedPlant", plant);
                    hit.transform.SendMessageUpwards("ChangeState", TileState.seeded);
                    Destroy(this.gameObject);
                }
            }
        }
        else if (!hit && Input.GetMouseButtonUp(0))
        {
            Destroy(this.gameObject);
        }
    }
}
