using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CT_Marshmallow : MonoBehaviour
{
    [System.NonSerialized]
    public Hand hand;
    public GameObject blade;
    public GameObject fake;
    public GameObject placed;
    public GameObject cooked;
    public GameObject smore;
    public float timer = 8.0f;
    bool roasting = false;
    public GameObject order;


    public void Update()
    {
        if (roasting)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = 0;
            }
        }
        else
        {
            timer = 8.0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (this.tag == "skewer" + blade.GetComponent<CT_BottomUp>().GetBottom() &&  other.tag == "skewer"  && blade.GetComponent<CT_PlaceMallow>().valid)
        {
            //Debug.Log("there");
            fake.gameObject.SetActive(false);
            placed.gameObject.SetActive(true);
            hand = other.GetComponent<Interactable>().attachedToHand;
            hand.DetachObject(other.gameObject);
            Destroy(other.gameObject);
        }
        else if (other.tag == "fire" && this.tag == "mallow" && placed.activeSelf)
        {
            roasting = true;
        }
        else if (other.tag == "assemble-" + this.tag)
        {
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<BoxCollider>().enabled = false;
            other.tag = "placed";
            other.transform.GetChild(0).gameObject.SetActive(true);
            cooked.gameObject.SetActive(false);
            fake.gameObject.SetActive(true);
            order.GetComponent<CT_SmoreOrder>().currentPieces++;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "fire" && this.tag == "mallow" && placed.activeSelf && roasting)
        {
            //Debug.Log("Countdown not done yet");
            if (timer <= 0)
            {
                roasting = false;
                placed.gameObject.SetActive(false);
                cooked.gameObject.SetActive(true);

            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "fire" && (this.tag == "mallow" || this.tag == "cooked mallow"))
        {
            Debug.Log("stop roast");
            roasting = false;
            timer = 8.0f;     
        }

    }

}

