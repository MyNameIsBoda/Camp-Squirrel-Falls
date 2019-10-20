using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CT_Skewer : MonoBehaviour
{
    [System.NonSerialized]
    public Hand hand;
    public bool tipEnter;

    private void Update()
    {
        hand = transform.parent.GetComponent<Interactable>().attachedToHand;
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("here");
        if (other.tag != ("respawn-skewer") && other.tag.Contains("skewer") && this.tag.Contains("skewer") && hand != null)
        {
            //Debug.Log("Tip bug: " + other + " " + this);
            tipEnter = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag != ("respawn-skewer") && other.tag.Contains("skewer") && this.tag.Contains("skewer"))
        {
            //Debug.Log("tip reset");
            tipEnter = false;
        }
    }
}
