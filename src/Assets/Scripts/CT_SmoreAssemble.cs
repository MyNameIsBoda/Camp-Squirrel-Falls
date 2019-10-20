using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CT_SmoreAssemble : MonoBehaviour
{

    [System.NonSerialized]
    public Hand hand;
    public int mutex = 0;
    AudioSource audioData;
    public GameObject order;

    void Start()
    {
        //audioData = transform.parent.GetComponent<AudioSource>();
        order = GameObject.Find("Order");
    }

    private void Update()
    {
        hand = GetComponent<Interactable>().attachedToHand;
    }

    void OnTriggerEnter(Collider other)
    {
       //Debug.Log("here");
        if (other.tag == "assemble-" + this.tag && hand != null && mutex == 0)
        {
            mutex = 1;
            //Debug.Log("there");
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<BoxCollider>().enabled = false;
            other.tag = "placed";
            other.transform.GetChild(0).gameObject.SetActive(true);
            //audioData.Play(0);
            hand.DetachObject(this.gameObject);
            order.GetComponent<CT_SmoreOrder>().currentPieces++;
            mutex = 0;
            Destroy(this.gameObject);

        }

    }
}
