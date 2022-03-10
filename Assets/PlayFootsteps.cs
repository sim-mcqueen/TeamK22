using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFootsteps : MonoBehaviour
{
    public AudioClip footStepOne;
    public AudioClip footStepTwo;

    private bool onOne = true;
    private AudioSource AS;

    private void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void FootStep()
    {
        if(onOne)
        {
            AS.PlayOneShot(footStepOne);
        }
        else
        {
            AS.PlayOneShot(footStepTwo);
        }
        onOne = (!onOne);
    }
}
