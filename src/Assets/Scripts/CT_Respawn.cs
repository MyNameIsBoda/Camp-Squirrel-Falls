using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CT_Respawn : MonoBehaviour
{

    [System.NonSerialized]
    public Hand hand;
    Vector3 startPosition;
    Quaternion startRotation;
    public ParticleSystem puff;
    private bool respawning = false;
    private bool inZone = false;
    public float detachTime = 0;
    public float lifeTime = 2;


    private void Start()
    {
        startPosition = this.transform.position;
        startRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        hand = GetComponent<Interactable>().attachedToHand;
        if(!inZone && hand == null)
        {
            //Debug.Log(hand);
            detachTime += Time.deltaTime;
            if (detachTime > lifeTime)
            {
                if (respawning == false)
                {
                    respawning = true;
                    Respawn();
                }

            }
        }
        else
        {
            //Debug.Log(hand);
            detachTime = 0;
        }
    }

    void Respawn()
    {
        //puff.Play();
        //Debug.Log("respawning");
        this.gameObject.transform.position = startPosition;
        this.gameObject.transform.rotation = startRotation;
        respawning = false;
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("here");
        if ((this.tag == "Short Log" || this.tag == "Long Log" || this.tag == "axe") && other.tag == "respawn-log")
        {
            inZone = true;

        }

        if (this.tag == "skewer-item" && other.tag == "respawn-skewer")
        {
            inZone = true;

        }

    }
    void OnTriggerExit(Collider other)
    {
        //Debug.Log("here");
        if ((this.tag == "Short Log" || this.tag == "Long Log" || this.tag == "axe") && other.tag == "respawn-log")
        {
            inZone = false;

        }

        if (this.tag == "skewer-item" && other.tag == "respawn-skewer")
        {
            inZone = false;

        }

    }
}
