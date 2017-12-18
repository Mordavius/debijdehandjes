using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantType { unknown, carrot, leek }

public abstract class Plant : MonoBehaviour
{
    public virtual PlantType plantType { get; protected set; }
    public virtual int valueOfHarvest { get; protected set; }
    public virtual float growthTimeInSeconds { get; protected set; }
    public virtual float growthMultiplier { get; protected set; }

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
        Debug.Log("ready()");
    }

    //public void HarvestPlant(Tile){}

}

public class Carrot : Plant
{
    public override PlantType plantType { get { return PlantType.carrot; } }
    public override float growthMultiplier { get { return 1.1f; } }
}

public class Leek : Plant
{
    public override int valueOfHarvest { get { return 12; } }
    public override PlantType plantType { get { return PlantType.leek; } }
    public override float growthMultiplier { get { return 0.8f; } }
}