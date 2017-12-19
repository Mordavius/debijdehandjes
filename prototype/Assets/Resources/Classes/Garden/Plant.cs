using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantType { unknown, carrot, leek }

public abstract class Plant : MonoBehaviour
{
    public virtual string plantName { get; set; }
    public virtual PlantType plantType { get; set; }
    public virtual int valueOfHarvest { get; set; }
    public virtual float growthTimeInSeconds { get; set; }
    public virtual float growthMultiplier { get; set; }

    public Tile tilePlantedOn { get; set; }
    public virtual Sprite plantSprite { get; set; }
    public virtual Sprite seedgroundSprite { get; set; }

    string path = "Sprites/Garden/Plants/";

    public Plant()
    {
        plantName = "unknown";
        valueOfHarvest = 10;
        plantType = PlantType.unknown;
        growthTimeInSeconds = 10 + Random.Range(-1,1);
        growthMultiplier = 1;
        plantSprite = Resources.Load<Sprite>(path + plantName);
        seedgroundSprite = Resources.Load<Sprite>(path + plantName + "-seeded-ground");
    }

    public void StartGrowing()
    {
        if (growthTimeInSeconds >= 0)
        {
            growthTimeInSeconds -= Time.deltaTime;
        }
        if (growthTimeInSeconds <= 0)
        {
            Ready();
        }
    }

    public void Ready()
    {
      
    }

    //public void HarvestPlant(Tile){}

}
