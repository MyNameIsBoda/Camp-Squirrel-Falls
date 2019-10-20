using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class CT_PlaceMallow : MonoBehaviour
{
    [System.NonSerialized]
    public Hand hand;
    public GameObject tip;
    public GameObject mallow1;
    public GameObject mallow2;
    public GameObject mallow3;
    public bool valid = false;

    private void Start()
    {
        mallow1 = transform.GetChild(0).gameObject;
        mallow2 = transform.GetChild(1).gameObject;
        mallow3 = transform.GetChild(2).gameObject;
    }

    private void Update()
    {
        hand = transform.parent.GetComponent<Interactable>().attachedToHand;
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("here");
        if (other.tag.Contains("skewer") && this.tag.Contains("skewer") && hand != null && tip.GetComponent<CT_Skewer>().tipEnter)
        {
            valid = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Contains("skewer") && this.tag.Contains("skewer") && hand != null)
        {
            valid = false;
        }
    }

    public void MarshmallowUpdate(int value)
    {
        switch (value)
        {
            case 0:
                mallow1.SetActive(true);
                mallow2.SetActive(false);
                mallow3.SetActive(false);
                break;
            case 1:
                mallow1.SetActive(true);
                mallow2.SetActive(true);
                mallow3.SetActive(false);
                break;
            case 2:
                mallow1.SetActive(true);
                mallow2.SetActive(true);
                mallow3.SetActive(true);
                break;
            default:
                print("Oops");
                break;
        }
    }
}
