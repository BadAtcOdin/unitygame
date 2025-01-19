using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreePointBalloon : Balloon
{
    protected override void Start()
    {
        base.Start();
        scoreValue = 3;
    }
}

