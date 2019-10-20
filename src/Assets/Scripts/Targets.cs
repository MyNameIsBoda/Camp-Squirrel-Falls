using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Targets : MonoBehaviour
{
    public GameObject target;
    public GameObject hardTarget;

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

    public GameObject rangeSelection;

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
        int currentTargets = GameObject.FindGameObjectsWithTag("Target").Length;
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
            SpawnTarget();
        }
    }

    public void SpawnTarget()
    {
        int targetType = 0;
        if (targetToggle.GetComponent<Toggle>().isOn)
        {
            targetType = Random.Range(0, 2);
        }

        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        GameObject temp;
        switch (targetType)
        {
            case 0:
                temp = Instantiate(target, pos, Quaternion.identity);
                break;
            case 1:
                temp = Instantiate(hardTarget, pos, Quaternion.identity);
                break;
            default:
                temp = Instantiate(target, pos, Quaternion.identity);
                Debug.Log("Oops");
                break;
        }

        temp.transform.eulerAngles -= new Vector3(0,180,0);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
