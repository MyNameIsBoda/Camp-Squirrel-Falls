using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Despawn : MonoBehaviour
{

    [System.NonSerialized]
    public Hand hand;
    public ParticleSystem puff;
    private bool despawning = false;
    public float detachTime = 0;
    public float lifeTime = 8;
    public float killtime = .5f;

    // Update is called once per frame
    void Update()
    {
        hand = GetComponent<Interactable>().attachedToHand;
        if(hand == null)
        {
            //Debug.Log(hand);
            detachTime += Time.deltaTime;
            if(detachTime > lifeTime)
            {
                if(despawning == false)
                {
                    despawning = true;
                    Kill();
                }
                
            }
        }
        else
        {
            //Debug.Log(hand);
            detachTime = 0;
        }
    }

    void Kill()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        puff.Play();
        Destroy(this.gameObject, killtime);
    }
}
