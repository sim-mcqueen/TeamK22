using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public float range;
    public GameObject platform;
    public int minTimeToWait;
    public int maxTimeToWait;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPlatform());
    }

    IEnumerator SpawnPlatform()
    {
        yield return new WaitForSeconds(Random.Range(minTimeToWait, maxTimeToWait));
        Instantiate(platform, new Vector3(transform.position.x, Random.Range(transform.position.y - range, transform.position.y + range)), Quaternion.identity);
        StartCoroutine(SpawnPlatform());
    }
}
