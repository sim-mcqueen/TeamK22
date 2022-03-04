using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public float range;
    public GameObject[] objectToSpawn;
    public float minTimeToWait;
    public float maxTimeToWait;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(Random.Range(minTimeToWait, maxTimeToWait));
        GameObject obj = Instantiate(objectToSpawn[Random.Range(0, objectToSpawn.Length)], new Vector3(transform.position.x, Random.Range(transform.position.y - range, transform.position.y + range)), Quaternion.identity);
        StartCoroutine(SpawnObject());
    }
}
