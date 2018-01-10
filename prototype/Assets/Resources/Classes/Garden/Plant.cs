using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : ScriptableObject
{
    public virtual string plantName { get; set; }
    public virtual int valueOfHarvest { get; set; }
    public virtual float growthTimeInSeconds { get; set; }
    public virtual float growthMultiplier { get; set; }

    public Tile tilePlantedOn { get; set; }
    public Sprite seedSprite { get; set; }
    public Sprite plantSprite { get; set; }
    private Sprite grownPlantSprite { get; set; }
    private Sprite groundSprite { get; set; }
    private float waterMultiplier { get; set; }

    public bool ready = false;
    public bool isWatered = false;

    private string spritePath = "Sprites/Garden/Plants/";

    public Plant()
    {
        plantName = "unknown";
        valueOfHarvest = 10;
        growthTimeInSeconds = 60;
        growthMultiplier = 1;
        waterMultiplier = 1;

        plantSprite = Resources.Load<Sprite>(spritePath + plantName);
        seedSprite = Resources.Load<Sprite>(spritePath + plantName + "-seed");
        grownPlantSprite = Resources.Load<Sprite>(spritePath + plantName + "-grown");
        groundSprite = Resources.Load<Sprite>(spritePath + plantName + "-dirtPile");
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
        isWatered = true;
        waterMultiplier = 3;
    }
}
