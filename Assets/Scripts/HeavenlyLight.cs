using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HeavenlyLight : MonoBehaviour
{
    public PostProcessVolume PostProcVolume;
    private Bloom bloom;
    public float bloomTime;
    private DeathEvent deathEvent;


    private void Awake()
    {
        deathEvent = FindObjectOfType<DeathEvent>();
    }
    private void Start()
    {
        PostProcVolume.profile.TryGetSettings(out bloom);
        deathEvent.OnDeath += DeathEvent_OnDeath;
    }

    private void DeathEvent_OnDeath(object sender, System.EventArgs e)
    {
        StartCoroutine(LerpBloom());
    }

    IEnumerator LerpBloom()
    {
        float elapsedTime = 0;

        while (elapsedTime < (bloomTime))
        {
            bloom.intensity.value = Mathf.Lerp(0, 100, elapsedTime / bloomTime);
            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
