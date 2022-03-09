using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomizeStarEvent : MonoBehaviour
{
    public event EventHandler OnRandomizeStar;
    public GameObject spawner;

    private Vector3 startPos;
    private PlatformSpawner platformScript;
    private RandomizeStarEvent starEvent;
    private bool isStarRandomized = false;
    private void Awake()
    {
        starEvent = FindObjectOfType<RandomizeStarEvent>();
        platformScript = spawner.GetComponent<PlatformSpawner>();
    }

    private void Start()
    {
        startPos = spawner.transform.position;
        starEvent.OnRandomizeStar += StarEvent_OnRandomizeStar;
    }

    private void StarEvent_OnRandomizeStar(object sender, EventArgs e)
    {
        if(isStarRandomized)
        {
            isStarRandomized = !isStarRandomized;
            spawner.transform.position = startPos;
            platformScript.range = 0;
        }
        else
        {
            isStarRandomized = !isStarRandomized;
            spawner.transform.position = new Vector3(spawner.transform.position.x, 0, spawner.transform.position.z);
            platformScript.range = 2;
        }
    }

    public void RandomizeStar()
    {
        OnRandomizeStar?.Invoke(this, EventArgs.Empty);
    }
}
