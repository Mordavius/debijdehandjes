using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lettuce : Plant
{
    public override string plantName { get { return "lettuce"; } }
    public override int valueOfHarvest { get { return 420; } }
    public override float growthMultiplier { get { return 12f; } }
}
