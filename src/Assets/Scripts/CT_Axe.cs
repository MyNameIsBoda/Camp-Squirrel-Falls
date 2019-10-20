using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CT_Axe : MonoBehaviour
{
    AudioSource hit;
    AudioSource place;
    [System.NonSerialized]
    public Hand hand;
    public GameObject blade;
    public GameObject log;
    public GameObject outline;
    GameObject parent;
    public SimpleHealthBar healthBar;
    public float health = 8.0f;
    public float maxHealth = 8.0f;
    public ParticleSystem splinters;
    public ParticleSystem puff;
    public int currentLog = 0;
    public GameObject[] placeables;
    public GameObject cutLog;
    public float cutVelocity = 1.5f;
    void Start()
    {
        hit = GetComponent<AudioSource>();
        place= outline.GetComponent<AudioSource>();
        parent = transform.parent.gameObject;
    }

    private void Update()
    {
        hand = parent.GetComponent<Interactable>().attachedToHand;
    }

    public void HealthUpdate(float value)
    {
        if(health == maxHealth || health >= value)
        {
            health = value;
        }
        maxHealth = value;
        healthBar.UpdateBar(health, maxHealth);
    }

    void BreakLog()
    {
        log.GetComponent<AudioSource>().Play(0);
        log.GetComponent<BoxCollider>().enabled = false;
        log.GetComponent<MeshRenderer>().enabled = false;
        puff.Play();
        GameObject selected = placeables[currentLog];
        cutLog = Instantiate(selected, selected.transform.position, selected.transform.rotation, selected.transform.parent); ;
        cutLog.SetActive(true);
        currentLog++;
    }

    public void PlaceLog()
    {
        //puff.Play();
        place.Play(0);
        log.GetComponent<BoxCollider>().enabled = true;
        log.GetComponent<MeshRenderer>().enabled = true;
        outline.GetComponent<BoxCollider>().enabled = false;
        outline.GetComponent<MeshRenderer>().enabled = false;
        health = maxHealth;
        healthBar.UpdateBar(health, maxHealth);
    }

    public void ShowOutline()
    {
        outline.GetComponent<BoxCollider>().enabled = true;
        outline.GetComponent<MeshRenderer>().enabled = true;
    }

    public void HideOutline()
    {
        outline.GetComponent<BoxCollider>().enabled = false;
        outline.GetComponent<MeshRenderer>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cut" && hand != null)
        {
            parent.GetComponent<Throwable>().GetReleaseVelocities(hand , out Vector3 velocity, out Vector3 angularVelocity);
            if (velocity.magnitude > cutVelocity && !blade.GetComponent<BoxCollider>().bounds.Intersects(log.GetComponent<BoxCollider>().bounds))
            {
                hit.Play(0);
                health--;
                healthBar.UpdateBar(health, maxHealth);
                splinters.Play();

                if(health <= 0)
                {
                    BreakLog();
                }

            }
        }
       
    }
}
