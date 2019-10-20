using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CT_Splash : MonoBehaviour
{
    public ParticleSystem puff;
    AudioSource splash;

    private void Start()
    {
        splash = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("here");
        if (other.tag == "Red" || other.tag == "Pink" || other.tag == "Purple")
        {
            //puff.Play();
            splash.Play(0);
        }

    }
}
