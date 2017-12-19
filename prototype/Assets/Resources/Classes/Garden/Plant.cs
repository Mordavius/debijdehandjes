using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantType { unknown, carrot, leek }

public abstract class Plant : MonoBehaviour
{
    public virtual PlantType plantType { get; set; }
    public virtual int valueOfHarvest { get; set; }
    public virtual float growthTimeInSeconds { get; set; }
    public virtual float growthMultiplier { get; set; }
    public Tile tilePlantedOn { get; set; }
    public Sprite[] plantSprites { get; set; }

    public Plant()
    {
        valueOfHarvest = 10;
        plantType = PlantType.unknown;
        growthTimeInSeconds = 10 + Random.Range(-1,1);
        growthMultiplier = 1;
    }

    public void StartGrowing()
    {
        if (growthTimeInSeconds >= 0)
        {
            Debug.Log(growthTimeInSeconds);
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
