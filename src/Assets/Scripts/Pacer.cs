using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pacer : MonoBehaviour
{
    public float startSpeed = 5.0f;
    public float speed;
    private float absxMax = 7.5f;
    private float absxMin = -5.5f; //starting position
    private float abszMax = 16f;
    private float abszMin = 2f; //starting position
    public float xMax;
    public float xMin; //starting position
    public float zMax;
    public float zMin; //starting position
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public float randomizer = .05f;
    float ranOffset;
    int direction;
    int xdirection;
    int zdirection;
    private GameObject targets;
    private GameObject speedslider;
    private GameObject lateralButton;
    private GameObject forwardButton;
    float modifier;
    bool canLateral;
    bool canForward;
    bool isLateral;
    bool isForward;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
        ranOffset = Random.Range(-randomizer, randomizer);
        direction = Random.Range(0, 2) * 2 - 1;
        xdirection = Random.Range(0, 2) * 2 - 1;
        zdirection = Random.Range(0, 2) * 2 - 1;

        //xMax = Random.Range(absxMin+2, absxMax);
        //xMin = Random.Range(absxMin, xMax);

        //zMax = Random.Range(abszMin, abszMax);
        //zMin = Random.Range(abszMin, zMax);

        xMax = absxMax;
        xMin = absxMin;
        zMax = abszMax;
        zMin = abszMin;

        //targets = GameObject.Find("Targets");
        //moveType = targets.GetComponent<Targets>().range;
        canLateral = (Random.value > 0.5f);
        canForward = (Random.value > 0.5f);

        speedslider = GameObject.Find("Target Speed");
        startSpeed = Random.Range(1, 1.75f);

        lateralButton = GameObject.Find("Lateral");
        forwardButton = GameObject.Find("Forward/Backward");


    }

    private void Update()
    {   
        modifier = speedslider.GetComponent<Slider>().value;
        speed = startSpeed * modifier;

        isLateral = lateralButton.GetComponent<Toggle>().isOn;
        isForward = forwardButton.GetComponent<Toggle>().isOn;

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * (frequency + ranOffset)) * amplitude * direction;

        float xNew = transform.position.x;
        if (isLateral && canLateral)
        {
            xNew = transform.position.x + xdirection * speed * Time.deltaTime;
            if (xNew >= xMax)
            {
                xNew = xMax;
                xdirection *= -1;
            }
            else if (xNew <= xMin)
            {
                xNew = xMin;
                xdirection *= -1;
            }
        }

        float zNew = transform.position.z;
        if (isForward && canForward)
        {
            zNew = transform.position.z + zdirection * speed * Time.deltaTime;
            if (zNew >= zMax)
            {
                zNew = zMax;
                zdirection *= -1;
            }
            else if (zNew <= zMin)
            {
                zNew = zMin;
                zdirection *= -1;
            }
        }


        

        // Spin object around Y-Axis
        //transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);



        transform.position = new Vector3(xNew, tempPos.y, zNew);
        //transform.position = new Vector3(xNew, transform.position.y, transform.position.z);
    }
}


