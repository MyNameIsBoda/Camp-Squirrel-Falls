using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CT_Stump : MonoBehaviour
{

    [System.NonSerialized]
    public Hand hand;
    AudioSource audioData;
    GameObject axe;

    private void Start()
    {
        Debug.Log(this.gameObject);
        axe = GameObject.Find("Edge").gameObject;
    }


    private void Update()
    {
        hand = GetComponent<Interactable>().attachedToHand;
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("here");
        if (this.tag == "Large Log" && other.tag == "outline" && hand != null)
        {
            axe.GetComponent<CT_Axe>().PlaceLog();
            hand.DetachObject(this.gameObject);
            Destroy(this.gameObject);
        }

    }
}
