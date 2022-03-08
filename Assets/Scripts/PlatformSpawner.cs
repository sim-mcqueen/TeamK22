using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public float range;
    public GameObject[] objectToSpawn;
    public float minTimeToWait;
    public float maxTimeToWait;
    private bool Spawning;
    private DeathEvent DE;

    private void Awake()
    {
        DE = FindObjectOfType<DeathEvent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObject());
        Spawning = true;
        DE.OnDeath += DE_OnDeath;
    }

    private void DE_OnDeath(object sender, System.EventArgs e)
    {
        Spawning = false;
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(Random.Range(minTimeToWait, maxTimeToWait));
        if(Spawning)
        {
            GameObject obj = Instantiate(objectToSpawn[Random.Range(0, objectToSpawn.Length)], new Vector3(transform.position.x, Random.Range(transform.position.y - range, transform.position.y + range)), Quaternion.identity);
            StartCoroutine(SpawnObject());
        }
        
    }
}
