using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRandomizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float scale = Random.Range(.75f, 1.5f);
        float shift = Random.Range(-.05f, .05f);
        int rot = Random.Range(0, 360);

        Vector3 displacement = new Vector3(0, shift, 0);
        Vector3 rotation = new Vector3(0, rot, 0 );

        transform.localScale *= scale;
        transform.position += displacement;
        transform.eulerAngles += rotation;

    }
}
