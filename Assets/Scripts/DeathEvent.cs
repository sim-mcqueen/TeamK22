using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DeathEvent : MonoBehaviour
{
    public event EventHandler OnDeath;

    public void Death()
    {
        OnDeath?.Invoke(this, EventArgs.Empty);
    }
}
