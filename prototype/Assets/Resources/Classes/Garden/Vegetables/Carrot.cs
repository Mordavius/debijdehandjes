using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Plant
{
    public override string plantName { get { return "carrot"; } }
    public override float growthMultiplier { get { return 1.1f; } }
}
