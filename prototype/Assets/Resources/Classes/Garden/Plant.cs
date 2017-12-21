using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantType { unknown, carrot, leek }

public abstract class Plant : ScriptableObject
{
    public virtual string plantName { get; set; }
    public virtual PlantType plantType { get; set; }
    public virtual int valueOfHarvest { get; set; }
    public virtual float growthTimeInSeconds { get; set; }
    public virtual float growthMultiplier { get; set; }

    public Tile tilePlantedOn { get; set; }
    public Sprite plantSprite { get; set; }
    public Sprite grownPlantSprite { get; set; }
    public Sprite groundSprite { get; set; }
    public float waterMultiplier { get; set; }

    public bool ready = false;

    string path = "Sprites/Garden/";

    public Plant()
    {
        plantName = "unknown";
        valueOfHarvest = 10;
        plantType = PlantType.unknown;
        growthTimeInSeconds = 20;
        growthMultiplier = 1;
        waterMultiplier = 1;

        plantSprite = Resources.Load<Sprite>(path + "Plants/" + plantName);
        grownPlantSprite = Resources.Load<Sprite>(path + "Plants/" + plantName + "-grown");
        groundSprite = Resources.Load<Sprite>(path + plantName + "-dirtPile");
    }

    public void GrowPlant(Tile tilePlantedOn)
    {
        if (growthTimeInSeconds >= 0)
        {
            tilePlantedOn.ChangeSprite(groundSprite);
            growthTimeInSeconds -= Time.deltaTime*growthMultiplier*waterMultiplier;
        }
        if (growthTimeInSeconds <= 0)
        {
            tilePlantedOn.ChangeSprite(grownPlantSprite);
            ready = true;
            tilePlantedOn.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void GetWatered()
    {
        waterMultiplier = 2;
    }

    //public void HarvestPlant(Tile){}

}
