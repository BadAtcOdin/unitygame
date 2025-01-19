using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FivePointBalloon : Balloon
{
    protected override void Start()
    {
        base.Start();
        scoreValue = 5;
    }
}
