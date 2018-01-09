using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leek : Plant
{
    public override string plantName { get { return "leek"; } }
    public override int valueOfHarvest { get { return 12; } }
    public override float growthMultiplier { get { return 0.5f; } }
}