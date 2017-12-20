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
    
    void OnTriggerStay2D(Collider2D other)
    {
        Tile targetScript = other.gameObject.GetComponent<Tile>();
        if (targetScript)
        {
            if (targetScript.state == (int)TileState.raked && Input.GetMouseButtonUp(0))
            {
                // send data to the tile, see TileBehaviour.cs
                other.transform.SendMessageUpwards("SeedPlant", plant);
                other.transform.SendMessageUpwards("ChangeState", (int)TileState.seeded);
                Destroy(this.gameObject);
            }
        }
        if (Input.GetMouseButtonUp(0) && other.gameObject.tag != "RakedGround")
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        if (hit.collider.tag != "RakedGround" && Input.GetMouseButtonUp(0))
        {
            Destroy(this.gameObject);
        }
    }
}
