using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDead : MonoBehaviour
{
    private GameObject all;
    private GameObject noRope;
    private GameObject noBalloon;
    private GameObject noBase;

    // Start is called before the first frame update
    void Start()
    {
        all  = transform.GetChild(0).gameObject;
        noRope = transform.GetChild(1).gameObject;
        noBalloon = transform.GetChild(2).gameObject;
        noBase = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(all.activeSelf + " " + noRope.activeSelf + " " + noBalloon.activeSelf + " " + noBase.activeSelf);
        if(!all.activeSelf && !noRope.activeSelf && !noBalloon.activeSelf && !noBase.activeSelf)
        {
            Debug.Log("KILL");
            Destroy(this.gameObject);
        }
    }
}
