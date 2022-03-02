using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInvis : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
