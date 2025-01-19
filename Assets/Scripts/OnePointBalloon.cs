using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePointBalloon : Balloon
{
    protected override void Start()
    {
        base.Start();
        scoreValue = 1;
    }
}