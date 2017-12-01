using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlantType { carrot=1, leek }

public abstract class Plant
{
    public virtual int    score         { get; protected set; }
    public virtual int    plantType     { get; protected set; }
    public virtual float  growthSpeed   { get; protected set; }

    public Plant()
    {
        score = 10;
        growthSpeed = 1;
        plantType = 0;
    }
}

public class Carrot : Plant
{
    public override int   score         { get { return 10; } }
    public override int   plantType     { get { return (int)PlantType.carrot; } }
    public override float growthSpeed   { get { return 1.1f; } }
}

public class Leek : Plant
{
    public override int   score         { get { return 12; } }
    public override int   plantType     { get { return (int)PlantType.leek; } }
    public override float growthSpeed   { get { return 0.8f; } }
}

public class SeedTouch : MonoBehaviour {

    public int plantType;
    public Plant plant;
    public Sprite[] sprite;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprite[plantType];
        switch (plantType)
        {
            case 1:
                plant = new Carrot();
                this.transform.localScale -= new Vector3(.005f, .005f, .005f);
                break;
            case 2:
                plant = new Leek();
                this.transform.localScale += new Vector3(.05f, .05f, .05f);
                break;
            default:
                plant = new Carrot();
                break;
        }
    }
    
void OnTriggerStay2D(Collider2D other)
    {
        TileBehaviour targetScript = other.gameObject.GetComponent<TileBehaviour>();
        Debug.Log("collide");
        if (targetScript.state == 1 && Input.GetMouseButtonUp(0))
        {
            other.transform.SendMessageUpwards("SeedPlant", plant);
            other.transform.SendMessageUpwards("ChangeState", 2);
            Destroy(this.gameObject);
        }
        if (Input.GetMouseButtonUp(0) && other.gameObject.tag != "RakedGround")
        {
            Destroy(this.gameObject);
        }
    }
}
