using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radish : Plant
{
    public override string plantName { get { return "radish"; } }
    public override int valueOfHarvest { get { return 6; } }
    public override float growthMultiplier { get { return 2f; } }
}
