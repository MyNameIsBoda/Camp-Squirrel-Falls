using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLock : MonoBehaviour
{
    Vector3 iniRot;
  
    void Start()
    {
        iniRot = transform.eulerAngles;
    }

    void LateUpdate()
    {
        //iniRot.z = transform.eulerAngles.z;
        //iniRot.y = transform.eulerAngles.y; // keep current rotation about Y
        //transform.eulerAngles = new Vector3(0, iniRot.y, iniRot.z); // restore original rotation with new Y
        float posx = Camera.main.transform.position.x;
        float posy = Camera.main.transform.position.y;
        float posz = Camera.main.transform.position.z;
        float rotx = Camera.main.transform.eulerAngles.x;
        float roty = Camera.main.transform.eulerAngles.y;
        float rotz = Camera.main.transform.eulerAngles.z;
        transform.position = new Vector3(posx, posy-.3f, posz);
        transform.eulerAngles = new Vector3(0, roty, rotz+90);
    }
}
