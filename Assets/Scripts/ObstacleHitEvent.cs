using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObstacleHitEvent : MonoBehaviour
{
    public event EventHandler OnHitObstacle;

    public void HitObstacle()
    {
        OnHitObstacle?.Invoke(this, EventArgs.Empty);
        print("hitObstacle");
    }
}
