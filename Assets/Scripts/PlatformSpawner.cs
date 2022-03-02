using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    //public int MaxWidth;
    public float upperBound;
    public float lowerBound;
    public float leftPos;
    public GameObject platform;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPlatform());
        StartCoroutine(SpawnPlatform());
        StartCoroutine(SpawnPlatform());

    }

    IEnumerator SpawnPlatform()
    {
        yield return new WaitForSeconds(Random.Range(1 ,5));
        Instantiate(platform, new Vector3(leftPos, Random.Range(lowerBound, upperBound)), Quaternion.identity);
        StartCoroutine(SpawnPlatform());
    }
}
