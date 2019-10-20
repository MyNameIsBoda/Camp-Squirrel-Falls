using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CT_CreateFire : MonoBehaviour
{
    public int placedLogs = 0;
    public GameObject[] shortLogs;
    public GameObject[] longLogs;
    public GameObject axe;
    GameObject fire;

    private void Start()
    {
        fire = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(placedLogs == 10)
        {
            fire.SetActive(true);
        }
    }

    public void BuildFire()
    {
        axe.GetComponent<CT_Axe>().HideOutline();
        foreach (GameObject shortLog in shortLogs)
        {
            shortLog.GetComponent<MeshRenderer>().enabled = false;
            shortLog.GetComponent<BoxCollider>().enabled = false;
            shortLog.tag = "placed";

            GameObject child = shortLog.transform.GetChild(0).gameObject;
            child.SetActive(true);
        }
        foreach (GameObject longLog in longLogs)
        {
            longLog.GetComponent<MeshRenderer>().enabled = false;
            longLog.GetComponent<BoxCollider>().enabled = false;
            longLog.tag = "placed";

            GameObject child = longLog.transform.GetChild(0).gameObject;
            child.SetActive(true);
        }
        placedLogs = 10;
    }

    public void ResetFire()
    {
        axe.GetComponent<CT_Axe>().ShowOutline();
        axe.GetComponent<CT_Axe>().currentLog = 0;
        foreach (GameObject shortLog in shortLogs)
        {
            shortLog.GetComponent<MeshRenderer>().enabled = true;
            shortLog.GetComponent<BoxCollider>().enabled = true;
            shortLog.tag = "Short Log";

            GameObject child = shortLog.transform.GetChild(0).gameObject;
            child.SetActive(false);
        }
        foreach (GameObject longLog in longLogs)
        {
            longLog.GetComponent<MeshRenderer>().enabled = true;
            longLog.GetComponent<BoxCollider>().enabled = true;
            longLog.tag = "Long Log";

            GameObject child = longLog.transform.GetChild(0).gameObject;
            child.SetActive(false);
        }
        placedLogs = 0;
        fire.SetActive(false);
    }
}
