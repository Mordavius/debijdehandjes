using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedTouch : MonoBehaviour {

    public int plantType;
    public Plant plant;
    public Sprite[] sprite;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprite[plantType];
        switch (plantType)
        {
            case (int)PlantType.carrot:
                plant = new Vegetables.Carrot();
                this.transform.localScale -= new Vector3(.005f, .005f, .005f);
                break;
            case (int)PlantType.leek:
                plant = new Vegetables.Leek();
                this.transform.localScale -= new Vector3(.005f, .005f, .005f);
                break;
            default:
                plant = new Vegetables.Carrot();
                this.transform.localScale -= new Vector3(.005f, .005f, .005f);
                break;
        }
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
                if (tilePlacedOn.state == (int)TileState.raked)
                {
                    hit.transform.SendMessageUpwards("SeedPlant", plant);
                    hit.transform.SendMessageUpwards("ChangeState", (int)TileState.seeded);
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
