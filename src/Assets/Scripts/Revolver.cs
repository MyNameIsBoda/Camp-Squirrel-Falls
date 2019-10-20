using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Revolver : MonoBehaviour
{
    public float speed2 = .1f;
    private float xPos = 0.0f;
    private float zPos = 0.0f;
    private float radius = 7.5f;
    private float theta = 0.0f;


    private void Update()
    {
        theta += speed2;
        xPos = (float)(radius * Math.Sin(theta));
        zPos = (float)(radius * Math.Cos(theta));
        transform.position = new Vector3(xPos, .5f, zPos);
    }
}
