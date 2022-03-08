using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlipCameraEvent : MonoBehaviour
{
    public event EventHandler onFlipCamera;

    public void HitObstacle()
    {
        onFlipCamera?.Invoke(this, EventArgs.Empty);
    }
}
