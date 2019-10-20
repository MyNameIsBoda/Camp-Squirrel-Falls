using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pondTargets : MonoBehaviour
{
    public GameObject pink;
    public GameObject purple;
    public GameObject red;

    public GameObject targetToggle;

    public Vector3 ecenter;
    public Vector3 esize;

    public Vector3 mcenter;
    public Vector3 msize;

    public Vector3 hcenter;
    public Vector3 hsize;

    public Vector3 center;
    public Vector3 size;

    public int range;
    public int sizeTarget;

    public GameObject rangeSelection;
    public GameObject sizeSelection;

    // Start is called before the first frame update
    void Start()
    {

        //center = transform.position;
        //SpawnTarget();
        range = rangeSelection.GetComponent<Dropdown>().value + 1;
    }

    // Update is called once per frame
    void Update()
    {
        int currentTargets = GameObject.FindGameObjectsWithTag("Fish").Length ;
        if (currentTargets < 1)
        {
            range = rangeSelection.GetComponent<Dropdown>().value + 1;
            switch (range)
            {
                case 1:
                    center = ecenter;
                    size = esize;
                    break;
                case 2:
                    center = mcenter;
                    size = msize;
                    break;
                case 3:
                    center = hcenter;
                    size = hsize;
                    break;
                default:
                    print("Oops");
                    break;
            }
            sizeTarget = sizeSelection.GetComponent<Dropdown>().value + 1;
            SpawnTarget();
        }
    }

    public void SpawnTarget()
    {
        int targetType = 0;

            targetType = Random.Range(0, 3);
        

        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), -0.08875f, Random.Range(-size.z / 2, size.z / 2));
        Quaternion rot = new Quaternion(-60, 0, -180, 0);

        GameObject temp;
        switch (targetType)
        {
            case 0:
                temp = Instantiate(pink, pos, pink.transform.rotation , pink.transform.parent);
                temp.SetActive(true);
                break;
            case 1:
                temp = Instantiate(purple, pos, purple.transform.rotation, purple.transform.parent);
                temp.SetActive(true);
                break;
            case 2:
                temp = Instantiate(red, pos, red.transform.rotation, red.transform.parent);
                temp.SetActive(true);
                break;
            default:
                temp = Instantiate(pink, pos, pink.transform.rotation, pink.transform.parent);
                temp.SetActive(true);
                Debug.Log("Oops");
                break;
        }

        if(sizeTarget == 1)
        {
            temp.transform.localScale = temp.transform.localScale * .75f;

        }
        else if (sizeTarget == 3)
        {
            temp.transform.localScale = temp.transform.localScale * 1.25f;

        }
        temp.transform.eulerAngles -= new Vector3(0,180,0);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
