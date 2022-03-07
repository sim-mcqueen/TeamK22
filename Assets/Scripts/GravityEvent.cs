using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GravityEvent : MonoBehaviour
{
    public event EventHandler OnGravityChange;

    public void ChangeGravity()
    {
        OnGravityChange?.Invoke(this, EventArgs.Empty);
    }
}
