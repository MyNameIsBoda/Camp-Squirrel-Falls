using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CT_FeedFish : MonoBehaviour
{
    public ParticleSystem puff;
    AudioSource ding;
    public bool impatient = false;
    public Toggle button;
    public float timer = 0.0f;

    private void Start()
    {
        ding = GetComponent<AudioSource>();
    }

    private void Update()
    {
        impatient = button.isOn;
        if(impatient)
        {
            timer += Time.deltaTime;
            if(timer > 15)
            {
                Destroy(this.gameObject);
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("here");
        if (other.tag == this.tag)
        {
            puff.Play();
            ding.Play(0);
            GetComponent<MeshRenderer>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            //spawn
            Destroy(this.gameObject, 1.25f);
        }

    }
}
