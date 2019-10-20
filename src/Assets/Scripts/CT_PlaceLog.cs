using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CT_PlaceLog : MonoBehaviour
{

    [System.NonSerialized]
    public Hand hand;
    public int mutex = 0;
    public GameObject axe;
    public GameObject pit;
    AudioSource audioData;
    Vector3 startPosition;

    void Start()
    {
        audioData = transform.parent.GetComponent<AudioSource>();
        startPosition = this.transform.position;
    }

    private void Update()
    {
        hand = GetComponent<Interactable>().attachedToHand;
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("here");
        if (other.tag == this.tag && mutex == 0 && hand != null)
        {
            mutex = 1;
           // Debug.Log("there");
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<BoxCollider>().enabled = false;
            other.tag = "placed";
            other.transform.GetChild(0).gameObject.SetActive(true);
            audioData.Play(0);
            hand.DetachObject(this.gameObject);
            Destroy(this.gameObject);
            pit.GetComponent<CT_CreateFire>().placedLogs++;
            if(pit.GetComponent<CT_CreateFire>().placedLogs < 10)
            {
                axe.GetComponent<CT_Axe>().ShowOutline();
            }

        }

    }

    //void OnTriggerExit(Collider other)
    //{
    //    //Debug.Log("here");
    //    if ((other.tag == "Short Log" || other.tag == "Long Log") && this.tag == "respawn"  && hand != null)
    //    {
    //        this.transform.position = startPosition;

    //    }

    //}
}
