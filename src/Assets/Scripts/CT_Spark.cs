using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CT_Spark : MonoBehaviour
{

    [System.NonSerialized]
    public Hand hand;
    public ParticleSystem flame;
    public ParticleSystem flare;


    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("here");
        if (other.tag == this.tag && hand != null)
        {
            //Debug.Log("there");
            flame.Play();
            flare.Play();
        }

    }
}
