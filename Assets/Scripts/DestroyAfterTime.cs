using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public int WaitTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyTime());
    }

    IEnumerator DestroyTime()
    {
        yield return new WaitForSeconds(WaitTime);
        Destroy(gameObject);
    }
}
